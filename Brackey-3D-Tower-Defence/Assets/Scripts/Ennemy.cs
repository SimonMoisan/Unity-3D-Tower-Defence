using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] public int worth;    //Money won when killed
    [SerializeField] public float startSpeed;
    [HideInInspector] public float speed;

    public GameObject explosion;

    private Transform target;

    void Start()
    {
        speed = startSpeed;
    }

    public void TakingDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    public void SlowMovement(float slowPercent)
    {
        speed = startSpeed * (1f - (slowPercent / 100));
    }

    public void ReashEnd()
    {
        PlayerStats.lives -= 1;
        Destroy(gameObject);
    }

    void Die()
    {
        PlayerStats.money += worth;
        Destroy(gameObject);
    }
}
