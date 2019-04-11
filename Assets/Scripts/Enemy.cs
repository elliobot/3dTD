using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float maxEnemyHealth = 10f;
    public float goldDrop = 1f;
    private float currentEnemyHealth;
    public Color startColour = Color.green;
    public Color endColour = Color.red;


    public float currentFrame = 0f;
    public GameObject deathEffect;

    public Mesh animation1 = null;
    public Mesh animation2 = null;
    public Mesh animation3 = null;
    public MeshFilter currentAnim;
    public float Animationcountdown = 1f;
    public float currentcountdown;
    // Use this for initialization
    void Start () {
        currentcountdown = Animationcountdown;
        maxEnemyHealth += Mathf.Round(2.5f * WaveMaster.instance.waveNumber);
        currentEnemyHealth = maxEnemyHealth;
        goldDrop = 10 + Mathf.Round(WaveMaster.instance.waveNumber / 5);
    }

    // Update is called once per frame
    void Update () {
        currentcountdown -= Time.deltaTime;

        if (currentcountdown <= 0f)
        {
            if (currentFrame == 4)
            {
                currentFrame = 0;
                Animationtick(currentFrame);
            }
            else
            Animationtick(currentFrame);
            currentFrame++;
            currentcountdown = Animationcountdown;
        }
    }

    public void Animationtick(float currentAnimation)
    {
         currentAnim = this.GetComponentInChildren<MeshFilter>();


        if (currentAnimation == 0)
        {
            currentAnim.mesh = animation3;
        }
        else if (currentAnimation == 1)
        {
            currentAnim.mesh = animation2;

        }
        else if (currentAnimation == 2)
        {
            currentAnim.mesh = animation3;

        }
        else if (currentAnimation == 3)
        {
            currentAnim.mesh = animation1;

        }

    }

    public void RecieveDamage(float damage)
    {
        currentEnemyHealth = currentEnemyHealth - damage;
        if (currentEnemyHealth <= 0)
        {
            ResourceManager.instance.gold += goldDrop;
            GameObject deathFx = (GameObject)Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(deathFx, 2f);

        }
    }
}
