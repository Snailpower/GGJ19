using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;

public class RadioSystem : MonoBehaviour
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
        
    }

    public void Particlespawn(float off0on1, GameObject particlesystem)
    {

        if (particles == null && off0on1 == 1)
        {
            particles = Instantiate(particlesystem, transform.position, Quaternion.identity);
        }
        else if (particles != null && off0on1 == 0)
        {
            Destroy(particles);
        }
    }

    public void TurnOnOff(float off0on1)
    {
        audiosources.transform.GetChild(3).GetComponents<StudioEventEmitter>()[0].SetParameter("Radio Param", off0on1);
        if (off0on1 == 0)
        {
            Destroy(particles);
        }
    }
}
