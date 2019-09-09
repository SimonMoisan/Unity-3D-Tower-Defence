using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;
    public TurretBlueprint standardTurret;
    private TurretBlueprint turretToBuild;

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
        turretToBuild = standardTurret;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Not enought money to build !");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;

        GameObject turret = Instantiate(turretToBuild.prefabTurret, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Remaining money : " + PlayerStats.money);
    }
}
