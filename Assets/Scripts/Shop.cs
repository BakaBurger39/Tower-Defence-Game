using UnityEngine;

public class Shop : MonoBehaviour
{

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchasePortalTurret()
    {
        Debug.Log("Portal Turret Purchased");
        buildManager.SetTurretToBuild(buildManager.portalTurretPrefab);
    }
}
