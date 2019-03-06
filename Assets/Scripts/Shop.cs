using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandard ()
    {
        Debug.Log("Chaching");
        buildManager.SetTurretToBuild(buildManager.standardTower);
    }
    public void PurchaseMinigun()
    {
        Debug.Log("Chaching2");
        buildManager.SetTurretToBuild(buildManager.minigunTower);

    }
    public void PurchaseSniper()
    {
        Debug.Log("Chaching3");
        buildManager.SetTurretToBuild(buildManager.sniperTower);

    }


    public void ChopWood()
    {
       ResourceManager.instance.wood += ResourceManager.instance.woodClickRate;
    }
}
