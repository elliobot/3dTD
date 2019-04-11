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

    public void PurchaseUpgrade(float cost, float goldincrease)
    {
        Debug.Log("Chaching");
        ResourceManager.instance.gold -= cost;
        ResourceManager.instance.goldPerSecond += ResourceManager.instance.goldPerSecond;
         
    }
    // Update is called once per frame
    void Update () {
		
	}
}
