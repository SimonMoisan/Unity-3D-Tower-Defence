using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    [SerializeField] public float range;

    [Header("Use Bullet")]
    public GameObject bulletPrefab;
    [SerializeField] public float fireRate;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;
    public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]

    public string ennemyTag = "Ennemy";
    [SerializeField] public Transform firePoint;
    [SerializeField] public Transform rotationPoint;
    [SerializeField] public float rotationSpeed = 5f;
    Vector3 initialRotationPosition;

    

    // Start is called before the first frame update
    void Start()
    {
        initialRotationPosition = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            //RotateBackToNormal();

            if(useLaser)
            {
                if(lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }

            return;
        }
        RotateTurretOnTarget();

        if (!useLaser)
        {
            if (fireCountdown <= 0f)
            {
                ShootBullet();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
        else
        {
            ShootLaser();
        }
    }

    void ShootBullet()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void ShootLaser()
    {
        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);
    }

    void RotateTurretOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotationPoint.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
    }

    void RotateBackToNormal()
    {
        Quaternion initialRotation = Quaternion.LookRotation(initialRotationPosition);
        Vector3 rotation = Quaternion.Lerp(rotationPoint.rotation, initialRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotationPoint.rotation = Quaternion.Euler(-90f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpdateTarget()
    {
        //We are loonking for every ennemy in the game
        GameObject[] ennemies = GameObject.FindGameObjectsWithTag(ennemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnnemy = null;

        foreach(GameObject ennemy in ennemies)
        {
            float distanceToEnnemy = Vector3.Distance(transform.position, ennemy.transform.position);
            if(distanceToEnnemy < shortestDistance)
            {
                shortestDistance = distanceToEnnemy;
                nearestEnnemy = ennemy;
            }
        }

        if(nearestEnnemy != null && shortestDistance <= range)
        {
            target = nearestEnnemy.transform;
        }
        else
        {
            target = null;
        }
    }
}
