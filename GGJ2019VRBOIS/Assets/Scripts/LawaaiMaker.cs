using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LawaaiMaker : MonoBehaviour
{
    public List<GameObject> Interactables;

    public GameObject particlesystem;

    private GameObject CurrentObject;

    public float noiseIntervalTime;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = noiseIntervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            CurrentObject = Interactables[Mathf.RoundToInt(Random.Range(0, Interactables.Count))];

            if (CurrentObject.name == "Door")
            {
                CurrentObject.GetComponent<DoorSystem>().DoorKick();
            }

            if (CurrentObject.name == "Laptop")
            {
                CurrentObject.GetComponent<LaptopSystem>().LaptopKick();
            }

            if (CurrentObject.name == "Window")
            {
                CurrentObject.GetComponent<WindowSystem>().WindowKick();
            }

            if (CurrentObject.name == "Radio")
            {
                CurrentObject.GetComponent<RadioSystem>().Particlespawn(1f, particlesystem);
                CurrentObject.GetComponent<RadioSystem>().TurnOnOff(1f);
            }

            if (CurrentObject.name == "TV")
            {
                CurrentObject.GetComponent<TvScript>().enableWhiteNoise();
            }

            if (CurrentObject.name == "Phone")
            {
                CurrentObject.GetComponent<PhoneSystem>().PhoneRing(1);
            }

            currentTime = noiseIntervalTime;
        }
    }
}
