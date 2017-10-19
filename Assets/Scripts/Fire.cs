using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public ParticleSystem fire; //the fire 
    public Light fireLight;
    private bool fireOn = false; //if the fire is on

	// Use this for initialization
	void Start () {
        fire.Stop();
        fireLight.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T))
        {
            if (fireOn)
            {
                fire.Stop();
                fireLight.intensity = 0;
                fireOn = false;
            }
            else
            {
                fire.Play();
                fireLight.intensity = 15;
                fireOn = true;
            }
        }
	}
}
