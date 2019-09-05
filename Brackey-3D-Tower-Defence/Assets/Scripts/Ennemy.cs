using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public List<Transform> waypoints;
    public GameObject explosion;

    private Transform target;
    private int waypointIndex = 0;

    void Start()
    {
        transform.position = EnnemyPath.points[waypointIndex].transform.position;
    }

    void Update()
    {
        MoveEnnemy();
    }

    void MoveEnnemy()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
