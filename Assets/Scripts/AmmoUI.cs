using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour {

    public int ammoTotal;
    public int ammoCurrent;
    public GameObject ammoDisplay;

	// Use this for initialization
	void Start () {
        ammoTotal = GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").Find("WeaponHolder").Find("AK47 Holder").Find("FPS-AK47").GetComponent<Weapon>().bulletsLeft;
        ammoCurrent = GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").Find("WeaponHolder").Find("AK47 Holder").Find("FPS-AK47").GetComponent<Weapon>().currentBullets;
    }
	
	// Update is called once per frame
	void Update () {
        ammoTotal = GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").Find("WeaponHolder").Find("AK47 Holder").Find("FPS-AK47").GetComponent<Weapon>().bulletsLeft;
        ammoCurrent = GameObject.Find("FPSController").transform.Find("FirstPersonCharacter").Find("WeaponHolder").Find("AK47 Holder").Find("FPS-AK47").GetComponent<Weapon>().currentBullets;
        ammoDisplay.GetComponent<Text>().text = ammoCurrent + "/" + ammoTotal;
    }
}
