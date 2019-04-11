using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour {

    public static ResourceManager instance;

    [Header("Game Settings")]
    public float gold = 100f;
    public float health = 20f;

    public float countdown = 1f;
    public float goldPerSecond = 1f;

    public float goldTickRate = 1f;


    [Header("HUD Text")]
    public Text goldText;
    public Text healthText;
    public Text roundText;

    [Header("Mouse Text")]
    public Text mouseText;
    public RectTransform MovingObject;
    public RectTransform BasisObject;
    public Camera cam;
    public Vector3 offset;
    public GameObject MouseTextObj;

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
            countdown = goldTickRate;
        }
        countdown -= Time.deltaTime;

        healthText.text = health.ToString();

        goldText.text = gold.ToString() + " (+" + goldPerSecond + "/s)";
        roundText.text = "Wave: " + (WaveMaster.instance.waveNumber - 1).ToString();
    }

    public void MoveObjet()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = 0;

        MovingObject.position = pos + offset;
    }

}
