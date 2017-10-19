using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Vector3.zero, Vector3.right, 5f * Time.deltaTime); //rotate to the right at speed 10f*time
        transform.LookAt(Vector3.zero); //look at the position 0
    }
}
