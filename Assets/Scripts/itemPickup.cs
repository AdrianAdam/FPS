using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").Find("WeaponHolder").Find("AK47 Holder").Find("FPS-AK47").GetComponent<Weapon>().addBullets();
        GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").Find("WeaponHolder").Find("AK47 Holder").Find("FPS-M4").GetComponent<Weapon>().addBullets();
        GameObject.Find("FPSController").transform.GetComponent<HealthController>().addHealth();

        Destroy(gameObject);
    }
}
