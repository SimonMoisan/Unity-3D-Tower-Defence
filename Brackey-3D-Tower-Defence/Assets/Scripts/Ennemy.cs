using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] public float speed;
    public GameObject explosion;

    private Transform target;
    private int wavepointIndex = 0;

    void Start()
    {
        target = EnnemyPath.points[wavepointIndex];
    }

    void Update()
    {
        Vector3 targetPosition = target.position - transform.position;
        transform.Translate(targetPosition.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= EnnemyPath.points.Length -1)
        {
            Destroy(gameObject);
        }

        wavepointIndex++;
        target = EnnemyPath.points[wavepointIndex];
    }
}
