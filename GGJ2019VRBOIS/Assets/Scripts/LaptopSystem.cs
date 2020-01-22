using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class LaptopSystem : MonoBehaviour
{
    private GameObject audiosources;
    private GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        audiosources = GameObject.FindWithTag("AudioObj");
    }

    // Update is called once per frame
    void Update()
    {
        audiosources.transform.GetChild(2).GetComponent<StudioEventEmitter>().SetParameter("Fortnite Param", transform.GetChild(1).GetComponent<HingeJoint>().angle / 110);
        audiosources.transform.GetChild(2).GetComponents<StudioEventEmitter>()[1].SetParameter("Will Smith Param", transform.GetChild(1).GetComponent<HingeJoint>().angle / 110);
    }

    public void LaptopKick()
    {
        transform.GetChild(1).GetComponent<Rigidbody>().AddRelativeForce(Vector3.back, ForceMode.Impulse);
        transform.GetChild(1).GetComponent<Rigidbody>().AddRelativeForce(Vector3.back, ForceMode.Impulse);
    }
}
