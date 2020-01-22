using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PhoneSystem : MonoBehaviour
{
    private GameObject audiosources;

    [HideInInspector]
    public bool grabbed;

    private bool calling;

    // Start is called before the first frame update
    void Start()
    {
        grabbed = false;
        audiosources = GameObject.FindWithTag("AudioObj");
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            calling = true;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PhoneHolder")
        {
            
            if (!grabbed)
            {
                CallStart(0);
                GetComponent<Rigidbody>().isKinematic = true;

                calling = false;
            }
            
        }
    }

    public void PhoneRing(float off0on1)
    {
        if (!calling)
        {
            audiosources.transform.GetChild(5).GetComponents<StudioEventEmitter>()[0].SetParameter("TelephoneParam", off0on1);
        }
        
    }

    public void CallStart(float off0on1)
    {
        transform.GetChild(0).GetComponents<StudioEventEmitter>()[0].SetParameter("CallingParam", off0on1);
    }

    public void SetGrabbed(bool value)
    {
        grabbed = value;
    }
}
