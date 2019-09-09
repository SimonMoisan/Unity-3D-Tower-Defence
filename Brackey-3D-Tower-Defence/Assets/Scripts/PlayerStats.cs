using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public static int lives;
    public static int startLives = 20;
    public int startMoney = 500;

    void Start()
    {
        money = startMoney;
        lives = startLives;
    }
}
