using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public GameObject[] buildableTurrets;
    private GameObject turretToBuild;

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager !");
        }
        instance = this;
    }

    void Start()
    {
        turretToBuild = buildableTurrets[0];
    }

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
