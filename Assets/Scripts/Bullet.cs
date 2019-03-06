using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;

    public GameObject impactEffect;
    public GameObject firstEnemy;

    public float Bulletdamage;

    public float speed = 70f;
    public void Seek (Transform _target)
    {
        target = _target;
    }


	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget(firstEnemy, Bulletdamage);
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget (GameObject firstEnemy, float damage)
    {
        if (firstEnemy != null)
        {
            firstEnemy.GetComponent<Enemy>().RecieveDamage(damage);

            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);

        }
        Destroy(gameObject);

    }

}
