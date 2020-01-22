using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class IntroLoop : MonoBehaviour
{
    public GameObject particles;

    public float timeforlaptop;

    private float currentTime;

    private bool introEnd;

    // Start is called before the first frame update
    void Start()
    {
        introEnd = false;

        currentTime = timeforlaptop;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Monologue/Introduction", GetComponent<Transform>().position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime != 0 && introEnd == false)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                GetComponent<LawaaiMaker>().Interactables[1].GetComponent<LaptopSystem>().LaptopKick();

                GetComponent<LawaaiMaker>().enabled = true;

                introEnd = true;
            }
        }
        
    }


}
