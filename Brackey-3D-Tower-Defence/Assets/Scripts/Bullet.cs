using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    [SerializeField] public float speed;
    [SerializeField] public float radius = 0f;
    public GameObject impactParticle;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject impact = Instantiate(impactParticle, transform.position, transform.rotation);

        if(radius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(impact, 1.0f);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider collider in colliders)
        {
            if(collider.tag == "Ennemy")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform ennemy)
    {
        Destroy(ennemy.gameObject);
    }

    
}
