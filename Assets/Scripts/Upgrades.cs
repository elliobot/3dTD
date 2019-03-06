using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour {


    public static Upgrades instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one Upgrades");
            return;
        }

        instance = this;
    }

    public void PurchaseUpgrade(float cost, float woodincrease, float goldincrease, float woodclickincrease)
    {
        Debug.Log("Chaching");
        ResourceManager.instance.gold -= cost;
        ResourceManager.instance.woodPerSecond += woodincrease;
        ResourceManager.instance.woodClickRate += woodclickincrease;
        ResourceManager.instance.goldPerSecond += goldincrease;
         
    }
    // Update is called once per frame
    void Update () {
		
	}
}
