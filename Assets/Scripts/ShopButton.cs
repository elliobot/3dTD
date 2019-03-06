using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopbutton : MonoBehaviour {
    public GameObject childMenu;

    // Use this for initialization
    void Start()   
    {
        
	}
    private void ButtonPress()
    {
        if (childMenu.GetComponent<Renderer>().enabled == true)
        {
            childMenu.GetComponent<Renderer>().enabled = false;
        }
        else
            childMenu.GetComponent<Renderer>().enabled = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
