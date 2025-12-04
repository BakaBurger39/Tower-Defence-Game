using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint portalTurret;
    public TurretBlueprint lazerTurret;
    public TurretBlueprint cannonTurret;

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

    public void SelectLazerTurret()
    {
        Debug.Log("Lazer Turret Selected");
        buildManager.SelectTurretToBuild(lazerTurret);
    }

    public void SelectCannonTurret()
    {
        Debug.Log("Cannon Turret Selected");
        buildManager.SelectTurretToBuild(cannonTurret);
    }

}
