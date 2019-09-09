using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint gunTurret;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectMachinGunTurret()
    {
        buildManager.SelectTurretToBuild(gunTurret);
    }

    public void SelectRocketTurret()
    {
        buildManager.SelectTurretToBuild(rocketTurret);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
