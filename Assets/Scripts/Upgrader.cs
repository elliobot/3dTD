using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrader : MonoBehaviour {

    public float upgradeCost = 0f;
    public float woodIncrease = 0f;
    public float goldIncrease = 0f;
    public float woodclickincrease = 0f;

    public string upgradeDescription = "Placeholder";

    public Text goldText;
    public Text descText;

    public void Update()
    {
        goldText.text = upgradeCost.ToString() ;
        descText.text = upgradeDescription;
    }

    public void Clickeroni()
    {
        if (ResourceManager.instance.gold >= upgradeCost)
        {
            Upgrades upgradeMenu = Upgrades.instance;

            upgradeMenu.PurchaseUpgrade(upgradeCost, woodIncrease, goldIncrease, woodclickincrease);
            upgradeCost = upgradeCost * 2;

        }
    }
}                                         
