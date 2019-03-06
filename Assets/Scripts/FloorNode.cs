using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FloorNode : MonoBehaviour {

    public Vector3 positionOffset;

    public Color startColor;
    private Renderer rend;
    public GameObject turret;
    public bool selectionStatus;
    private GameObject selectedArea;

    public float upgradeLevel = 0f;

    public GameObject selectedAreaObjectFail;
    public GameObject selectedAreaObject;

    public float turretRange;
    public GameObject turretToBuild;
    private Turret turretSelected;
    BuildManager buildManager;
    public string selectTag = "Selection";

    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;
    }

    private void Update()
    {
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
            if (turret != null)
            {
                UpgradeTurret();
                upgradeLevel++;
            }
            else
            {
                if (buildManager.GetTurretToBuild() == null)
                {
                    return;
                }

                Vector3 PositionNew = new Vector3(transform.position.x - 5, transform.position.y + 22, transform.position.z - 6);
                turretSelected = turretToBuild.GetComponent<Turret>();

                if (ResourceManager.instance.gold < turretSelected.goldCost || ResourceManager.instance.wood < turretSelected.woodCost)
                {

                }
                else
                {
                    ResourceManager.instance.gold = ResourceManager.instance.gold - turretSelected.goldCost;
                    ResourceManager.instance.wood = ResourceManager.instance.wood - turretSelected.woodCost;
                    this.turret = (GameObject)Instantiate(turretToBuild, PositionNew, Quaternion.Euler(0, 0, 0));
                }
            }
        }
    }
    public void UpgradeTurret()
    {


        if (upgradeLevel == 0)
        {

        }
        else if (upgradeLevel == 1)
        {
            this.startColor = Color.green;
        }
        else if (upgradeLevel == 2)
        {
            this.startColor = Color.blue;
        }
        else if (upgradeLevel == 3)
        {
            this.startColor = Color.magenta;
        }
        else if (upgradeLevel == 4)
        {
            this.startColor = Color.yellow;

        }
    }
    void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (buildManager.GetTurretToBuild() == null)
            {
                return;
            }


            turretToBuild = BuildManager.instance.GetTurretToBuild();


            

            if (turretToBuild != null && turretSelected != null)
            {

                SelectArea();
            }

        }



    }
    private void OnMouseExit()
    {

        DeleteAreas();
        
        rend.material.color = startColor;
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
        if (ResourceManager.instance.gold >= turretSelected.goldCost && ResourceManager.instance.wood >= turretSelected.woodCost  )
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
        else if (ResourceManager.instance.gold < turretSelected.goldCost || ResourceManager.instance.wood < turretSelected.woodCost || this.turret != null)
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



    //public void SelectArea()
    //{

    //    if (BuildManager.instance.GetTurretToBuild() != null)
    //    {
    //        turretRange = turretSelected.range;

    //        if (ResourceManager.instance.gold >= turretSelected.goldCost && ResourceManager.instance.wood >= turretSelected.woodCost)
    //        {
    //            if (selectionStatus != selectedAreaObject)
    //            {

    //                this.selectionStatus = selectedAreaObject;

    //                this.selectedArea = (GameObject)Instantiate(selectionStatus, transform.position + positionOffset, transform.rotation);
    //                this.selectedArea.transform.localScale = new Vector3(turretRange, turretRange, 0);

    //            }
    //            return;
    //        }
    //        else
    //        {
    //            if (selectionStatus != selectedAreaObjectFail)
    //            {
    //                this.selectionStatus = selectedAreaObjectFail;
    //                this.selectedArea = (GameObject)Instantiate(selectionStatus, transform.position + positionOffset, transform.rotation);
    //                this.selectedArea.transform.localScale = new Vector3(turretRange, turretRange, 0);
    //            }
    //            return;
    //        }
    //    }
    //    DeleteAreas();
    //}

}
