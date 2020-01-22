using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class WindowSystem : MonoBehaviour
{
    private GameObject audiosources;

    public bool handlegrabbed;

    private GameObject particles;

    // Start is called before the first frame update
    void Start()
    {
        handlegrabbed = false;
        audiosources = GameObject.FindWithTag("AudioObj");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition.y >= .3f && handlegrabbed == false)
        {
            if (GetComponent<Rigidbody>().isKinematic == false)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        audiosources.transform.GetChild(1).GetComponent<StudioEventEmitter>().SetParameter("Closed Open", transform.localPosition.y / 0.312114f);

        if (transform.localPosition.y <= .1f)
        {
            Destroy(particles);
        }
    }

    public void SetGrabbed(bool value)
    {
        handlegrabbed = value;
    }

    public void WindowKick()
    {
        for (int i = 0; i < 5; i++)
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up, ForceMode.Impulse);
        }
    }
}
