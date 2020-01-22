using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class DoorSystem : MonoBehaviour
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
        audiosources.transform.GetChild(0).GetComponent<StudioEventEmitter>().SetParameter("Door Closed Open", GetComponent<HingeJoint>().angle / 90);
    }


    
    public void DoorKick()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward, ForceMode.Impulse);
    }
}
