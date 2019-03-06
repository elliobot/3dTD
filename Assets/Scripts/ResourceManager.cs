using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;


    public float gold = 100f;
    public float wood = 20f;
    public float health = 20f;

    public float countdown = 1f;
    public float goldPerSecond = 1f;
    public float woodPerSecond = 1f;

    public float goldTickRate = 1f;
    public float woodClickRate = 1f;

    public Text goldText;
    public Text woodText;
    public Text healthText;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one ResourceManager");
            return;
        }

        instance = this;
    }
    // Update is called once per frame
    void Update () {
        if (countdown <= 0f)
        {
            gold = gold + goldPerSecond;
            wood = wood + woodPerSecond;
            countdown = goldTickRate;
        }
        countdown -= Time.deltaTime;

        healthText.text = health.ToString();

        goldText.text = gold.ToString() + " (+" + goldPerSecond + "/s)";
        woodText.text = wood.ToString() + " (+" + woodPerSecond + "/s)";
    }



}
