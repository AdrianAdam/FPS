using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour {

    [SerializeField] private GameObject[] weapons; //all weapons in the game
    [SerializeField] private float switchDelay = 1f; //delay between weapon change

    private int index; //currently equipped weapon
    private bool isSwitching; //if i am switching the weapon

	// Use this for initialization
	void Start () {
        InitializeWeapons();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis("Mouse ScrollWheel") > 0 && !isSwitching)
        {
            index++;

            if (index >= weapons.Length)
                index = 0;

            StartCoroutine(switchAfterDelay(index));
        }

        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && !isSwitching)
            {
                index--;

                if (index < 0)
                    index = weapons.Length - 1;

                StartCoroutine(switchAfterDelay(index));
            }
        }
	}

    private void InitializeWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
    }

    private void switchWeapons(int newIndex)
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }

        weapons[newIndex].SetActive(true);
    }

    private IEnumerator switchAfterDelay(int newIndex)
    {
        isSwitching = true;

        yield return new WaitForSeconds(switchDelay);

        isSwitching = false;
        switchWeapons(newIndex);
    }
}
