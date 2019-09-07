using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Ennemy))]
public class EnnemyMovement : MonoBehaviour
{
    [SerializeField] public List<Transform> waypoints;
    [SerializeField] public WaveConfig waveConfig;
    private int waypointIndex = 0;

    private Ennemy ennemy;

    void Start()
    {
        ennemy = GetComponent<Ennemy>();
        waypoints = waveConfig.GetWaypoints();
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
            var movementThisFrame = ennemy.speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }

            //Reset speed
            ennemy.speed = ennemy.startSpeed;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
