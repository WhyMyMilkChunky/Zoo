using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZooController : MonoBehaviour
{ 
    public GameObject[] Sheep;
    public Material materialWool;
    public float rainbowSpeed;
    void Start()
    {
        StartCoroutine(RainbowSheep());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RainbowSheep()
    {
        while (true)
        {
            Color rainbowColor = Color.HSVToRGB(Time.time * rainbowSpeed % 1f, 1f, 1f);
            materialWool.color = rainbowColor;
            yield return null;
        }
    }
}
