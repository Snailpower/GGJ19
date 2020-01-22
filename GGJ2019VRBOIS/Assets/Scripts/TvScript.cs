using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class TvScript : MonoBehaviour
{
	public UnityEngine.Animator animator;

    private GameObject audiosources;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        audiosources = GameObject.FindWithTag("AudioObj");
    }

    public void enableWhiteNoise() {
    	animator.SetBool("Activated", true);
        audiosources.transform.GetChild(4).GetComponents<StudioEventEmitter>()[0].SetParameter("TVParam", 1);
    }
    public void disableWhiteNoise() {
    	animator.SetBool("Activated", false);
        audiosources.transform.GetChild(4).GetComponents<StudioEventEmitter>()[0].SetParameter("TVParam", 0);
    }    
}