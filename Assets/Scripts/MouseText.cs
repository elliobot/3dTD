using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseText : MonoBehaviour {



    public RectTransform MovingObject;
    public Vector3 offset;
    public RectTransform BasisObject;
    public Camera cam;

	
	// Update is called once per frame
	void Update () {

        MoveObjet();
        
    }
    public void MoveObjet()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0;
        MovingObject.position = pos;
    }
}
