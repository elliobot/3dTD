using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
    public GameObject childMenu;
    public bool flipObjectOnPress;
    // Use this for initialization
    void Start () {
		
	}
    public void newButtonPress()
    {
        if (flipObjectOnPress == true)
            if (childMenu.activeInHierarchy == true)
            {
                childMenu.SetActive(false);
                this.transform.Rotate(0, 0, 180);
            }
            else
            {
                childMenu.SetActive(true);
                this.transform.Rotate(0, 0, 180);
            }
        else
            if (childMenu.activeInHierarchy == true)
            {
            childMenu.SetActive(false);
            }
            else
            {
            childMenu.SetActive(true);
            }
    }
    

    // Update is called once per frame
    void Update () {

    }
}
