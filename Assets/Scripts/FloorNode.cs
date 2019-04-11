using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloorNode : MonoBehaviour {

    public Vector3 positionOffset;

    public Color startColor;
    private Renderer rend;
    public GameObject currentTurret;
    public bool selectionStatus;
    private GameObject selectedArea;

    public float upgradeLevel = 1f;

    [Header("Select AOE Settings")]
    public GameObject selectedAreaObjectFail;
    public GameObject selectedAreaObject;
    public GameObject selectedAreaObjectUpgrade;

    [Header("Turret Settings")]

    private Turret turretData;

    public float turretRange;
    public GameObject turretToBuild;
    private Turret turretSelected;
    BuildManager buildManager;
    public string selectTag = "Selection";

    [Header("Upgrade Settings")]
    public float upgradecost = 0f;





    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;
    }

    private void Update()
    {
        if (this.currentTurret != null)
        {
            
            if (upgradeLevel == 2)
            {
                this.startColor = Color.green;
            }
            else if (upgradeLevel == 3)
            {
                this.startColor = Color.blue;
            }
            else if (upgradeLevel == 4)
            {
                this.startColor = Color.magenta;
            }
            else if (upgradeLevel == 5)
            {
                this.startColor = Color.yellow;
            }
            else if (upgradeLevel == 6)
            {
                this.startColor = Color.red;
            }
            rend.material.color = startColor;

        }
        if (BuildManager.instance.GetTurretToBuild() != null)
        {
            turretToBuild = BuildManager.instance.GetTurretToBuild();
            turretSelected = turretToBuild.GetComponent<Turret>();
        }
        BuildManager.instance.selectedAreas = GameObject.FindGameObjectsWithTag("Selection");


    }

    private void OnMouseDown()
    {
        
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (currentTurret != null)
            {
                UpgradeTurret();
            }
            else
            {
                if (buildManager.GetTurretToBuild() == null)
                {
                    return;
                }

                Vector3 PositionNew = new Vector3(transform.position.x - 5, transform.position.y + 22, transform.position.z - 6);
                turretSelected = turretToBuild.GetComponent<Turret>();

                if (ResourceManager.instance.gold < turretSelected.goldCost)
                {

                }
                else
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - turretSelected.goldCost;
                    this.currentTurret = (GameObject)Instantiate(turretToBuild, PositionNew, Quaternion.Euler(0, 0, 0));
                    turretData = this.currentTurret.GetComponent<Turret>();
                    upgradecost = (upgradeLevel * Mathf.Round(turretData.goldCost / 2)) + 100;

                }
            }
        }
    }
    public void UpgradeTurret()
    {
        
        if (upgradeLevel != 6)
        {

            if (upgradeLevel == 1)
            {
                if (ResourceManager.instance.gold >= upgradecost)
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - upgradecost;
                    turretData.damage = turretData.damage * turretData.damageUpgrade;
                    turretData.range = turretData.range * turretData.rangeUpgrade;
                    turretData.fireRate = turretData.fireRate * turretData.attackspeedUpgrade;
                    upgradeLevel++;
                    upgradecost = upgradecost + (upgradeLevel * Mathf.Round(turretData.goldCost / 2)) + 100;

                }
            }
            else if (upgradeLevel == 2)
            {
                if (ResourceManager.instance.gold >= upgradecost)
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - upgradecost;
                    turretData.damage = turretData.damage * turretData.damageUpgrade;
                    turretData.range = turretData.range * turretData.rangeUpgrade;
                    turretData.fireRate = turretData.fireRate * turretData.attackspeedUpgrade;
                    upgradeLevel++;
                    upgradecost = upgradecost + (upgradeLevel * Mathf.Round(turretData.goldCost / 2)) + 100;

                }

            }
            else if (upgradeLevel == 3)
            {
                if (ResourceManager.instance.gold >= upgradecost)
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - upgradecost;
                    turretData.damage = turretData.damage * turretData.damageUpgrade;
                    turretData.range = turretData.range * turretData.rangeUpgrade;
                    turretData.fireRate = turretData.fireRate * turretData.attackspeedUpgrade;
                    upgradeLevel++;
                    upgradecost = upgradecost + (upgradeLevel * Mathf.Round(turretData.goldCost / 2)) + 100;

                }
            }
            else if (upgradeLevel == 4)
            {
                if (ResourceManager.instance.gold >= upgradecost)
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - upgradecost;
                    turretData.damage = turretData.damage * turretData.damageUpgrade;
                    turretData.range = turretData.range * turretData.rangeUpgrade;
                    turretData.fireRate = turretData.fireRate * turretData.attackspeedUpgrade;
                    upgradeLevel++;
                    upgradecost = upgradecost + (upgradeLevel * Mathf.Round(turretData.goldCost / 2)) + 100;

                }
            }
            else if (upgradeLevel == 5)
            {
                if (ResourceManager.instance.gold >= upgradecost)
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - upgradecost;
                    turretData.damage = turretData.damage * turretData.damageUpgrade;
                    turretData.range = turretData.range * turretData.rangeUpgrade;
                    turretData.fireRate = turretData.fireRate * turretData.attackspeedUpgrade;
                    upgradeLevel++;
                    upgradecost = upgradecost + (upgradeLevel * Mathf.Round(turretData.goldCost / 2)) + 100;

                }
            }

        }

    }
    void OnMouseOver()
    {
        if (this.currentTurret != null && turretData != null)
        {
            TowerRange();
            ResourceManager.instance.MoveObjet();


            if (this.upgradeLevel < 6)
            {
                ResourceManager.instance.mouseText.text = "Upgrade: " + upgradecost.ToString() + "g";
            }
            else
            {
                ResourceManager.instance.mouseText.text = "Upgrade: MAX";

            }

        }
        else
        {
            ResourceManager.instance.mouseText.text = "";

        }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (buildManager.GetTurretToBuild() == null)
            {
                return;
            }


            turretToBuild = BuildManager.instance.GetTurretToBuild();


            

            if (turretToBuild != null && turretSelected != null && currentTurret == null)
            {

                SelectArea();
            }

        }



    }
    private void OnMouseExit()
    {

        DeleteAreas();
        
        selectionStatus = false;
    }

    public void DeleteAreas()
    {
        foreach (GameObject selection in BuildManager.instance.selectedAreas)
        {
            Destroy(selection);
        }
    }

    public void SelectArea()
    {
        turretRange = turretSelected.range;
        if (ResourceManager.instance.gold >= turretSelected.goldCost)
        {
             if (selectedArea == null || selectionStatus == false)
             {
                DeleteAreas();
                selectionStatus = true;
                this.selectedArea = (GameObject)Instantiate(selectedAreaObject, transform.position + positionOffset, transform.rotation);
                this.selectedArea.transform.localScale = new Vector3(turretRange, turretRange, 0);
                return;
             }
            return;
        }
        else if (ResourceManager.instance.gold < turretSelected.goldCost || this.currentTurret != null)
        {
             if (selectedArea == null || selectionStatus == true)
             {
                DeleteAreas();
                selectionStatus = false;
                this.selectedArea = (GameObject)Instantiate(selectedAreaObjectFail, transform.position + positionOffset, transform.rotation);
                this.selectedArea.transform.localScale = new Vector3(turretRange, turretRange, 0);
                return;
             }
            return;
        }
        DeleteAreas();
        return;
    }

    public void TowerRange()
    {

            DeleteAreas();
            selectionStatus = true;
            this.selectedArea = (GameObject)Instantiate(selectedAreaObjectUpgrade, transform.position + positionOffset, transform.rotation);
            this.selectedArea.transform.localScale = new Vector3(turretData.range, turretData.range, 0);
            return;
    }

}
