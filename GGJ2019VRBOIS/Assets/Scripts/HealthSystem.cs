using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
using Valve;
using Valve.VR;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public Color deathcolor;

    public float piepSpeed;

    private bool ded;

    private GameObject audiosources;

    public GameObject piep;

    private float health;

    private float lawaai;

    private float lawaai1;

    private float lawaai2;

    private float lawaai3;

    private float lawaai4;

    private float lawaai5;

    private float lawaai6;

    public float timeuntildeath;

    private float currenttime;

    // Start is called before the first frame update
    void Start()
    {
        ded = false;
        currenttime = timeuntildeath;

        health = 0;
        audiosources = GameObject.FindWithTag("AudioObj");

    }

    // Update is called once per frame
    void Update()
    {

        audiosources.transform.GetChild(0).GetComponent<StudioEventEmitter>().EventInstance.getParameterValueByIndex(0, out lawaai1, out lawaai1);
        audiosources.transform.GetChild(1).GetComponent<StudioEventEmitter>().EventInstance.getParameterValueByIndex(0, out lawaai2, out lawaai2);
        audiosources.transform.GetChild(2).GetComponent<StudioEventEmitter>().EventInstance.getParameterValueByIndex(0, out lawaai3, out lawaai3);
        audiosources.transform.GetChild(3).GetComponent<StudioEventEmitter>().EventInstance.getParameterValueByIndex(0, out lawaai4, out lawaai4);
        audiosources.transform.GetChild(4).GetComponent<StudioEventEmitter>().EventInstance.getParameterValueByIndex(0, out lawaai5, out lawaai5);
        audiosources.transform.GetChild(5).GetComponent<StudioEventEmitter>().EventInstance.getParameterValueByIndex(0, out lawaai6, out lawaai6);

        lawaai = lawaai1 + lawaai2 + lawaai3 + lawaai4 + lawaai5 + lawaai6;

        if (lawaai > 0.9f)
        {
            if (health < .8f)
            {
                health += piepSpeed;
            }

            piep.GetComponent<StudioEventEmitter>().SetParameter("Piepparam", health);
        }

        else if (lawaai <= 0.9)
        {
            if (health > 0)
            {
                health -= 0.01f;
            }

            piep.GetComponent<StudioEventEmitter>().SetParameter("Piepparam", health);
        }

        if (health >= .8f)
        {
            currenttime -= Time.deltaTime;

            if (currenttime <= 0)
            {
                SteamVR_Fade.Start(deathcolor, .2f, false);

                if (!ded)
                {
                    FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Death", Camera.main.transform.position);

                    ded = true;
                }


                Invoke("RestartGame", 6f);
            }
        }

        else if (health < .8f)
        {
            currenttime = timeuntildeath;
        }


    }

    void RestartGame()
    {

        SceneManager.LoadScene(0);
    }
}
