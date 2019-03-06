using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour {

    public float speed = 10f;

    public float targetcurrent;

    private Transform target;

    private int wavepointIndex = 0;

	// Use this for initialization
	void Start () {
        target = Waypoints.points[1];

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWaypoint();
        }



        var lookPos = target.position - transform.position;



        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 1);
        targetcurrent = lookPos.x;


    }

    void GetNextWaypoint()
    {

        

        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            ResourceManager.instance.health -= 1;
            Destroy(gameObject);
        }
        else
        {

            wavepointIndex++;
            target = Waypoints.points[wavepointIndex];
        }

        


    }
}
