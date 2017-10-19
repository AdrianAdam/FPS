using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour {

    CharacterController characterCollider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        characterCollider = gameObject.GetComponent<CharacterController>();

        if (Input.GetKey(KeyCode.C))
            characterCollider.height = 1.0f;
        else characterCollider.height = 2.0f;
    }
}
