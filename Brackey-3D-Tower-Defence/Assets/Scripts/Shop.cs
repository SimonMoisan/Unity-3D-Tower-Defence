using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseMachinGunTurret()
    {
        buildManager.SetTurretToBuild(buildManager.buildableTurrets[0]);
    }

    public void PurchaseRocketTurret()
    {
        buildManager.SetTurretToBuild(buildManager.buildableTurrets[1]);
    }

    public void PurchaseLaserTurret()
    {
        buildManager.SetTurretToBuild(buildManager.buildableTurrets[2]);
    }
}
