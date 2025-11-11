using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint portalTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectPortalTurret()
    {
        Debug.Log("Portal Turret Selected");
        buildManager.SelectTurretToBuild(portalTurret);
    }
}
