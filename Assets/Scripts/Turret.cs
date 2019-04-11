using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {


    private Transform target;
    public GameObject firstEnemy;

    [Header("Attributes")]
    public float damage = 1f;
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    public float goldCost = 10f;

    [Header("Upgrade Info")]
    public float rangeUpgrade = 0f;
    public float damageUpgrade = 0f;
    public float attackspeedUpgrade = 0f;

    [Header("Unity Settings")]

    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    private int i = 0;


    // Use this for initialization
    void Start() {

        InvokeRepeating("UpdateTarget", 0f, 0.5f);

    }

    void UpdateTarget()
    {
        firstEnemy = TargetSelect();

        float distanceToEnemy = 99999;

        if (firstEnemy != null)
        {
            
            target = firstEnemy.transform;
             distanceToEnemy = Vector3.Distance(this.transform.position, firstEnemy.transform.position);

        }

        if (distanceToEnemy > range)
        {
            firstEnemy = null;
        }
       
    }

    public GameObject TargetSelect()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        firstEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < range)
            {
                firstEnemy = enemy;
                return enemy;
            }
            else
                firstEnemy = null;

        }

        if (firstEnemy == null)
        {
            return null;
        }

        return null;
    }

    // Update is called once per frame
    void Update() {

        if (target == null)
        {
            return;
        }
        Vector3 dir = target.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = lookRotation.eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y + 180f, 0f);


        if (fireCountdown <= 0 && firstEnemy != null)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        if (this.firePoint2 == null)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint1.position, Quaternion.Euler(90f, firePoint1.rotation.y + 90, 0f));
            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.Bulletdamage = damage;
            bullet.firstEnemy = firstEnemy;

            if (bullet != null)
                bullet.Seek(target);

        }
        else

        if (i == 0)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint1.position, Quaternion.Euler(90f, firePoint1.rotation.y + 90, 0f));

            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.Bulletdamage = damage;
            bullet.firstEnemy = firstEnemy;

            if (bullet != null)
                bullet.Seek(target);
            i = 1;
        }
        else if (i == 1)
        {
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint2.position, Quaternion.Euler(90f, firePoint2.rotation.y + 90, 0f));

            Bullet bullet = bulletGO.GetComponent<Bullet>();
            bullet.Bulletdamage = damage;
            bullet.firstEnemy = firstEnemy;


            if (bullet != null)
                bullet.Seek(target);
            i = 0;
        }



    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}