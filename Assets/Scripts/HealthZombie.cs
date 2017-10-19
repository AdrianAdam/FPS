using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZombie : MonoBehaviour {

    [SerializeField] public float health = 100; //to view in the editor
    public Transform item; //the item which is dropped
    public Transform clone;

    // Use this for initialization
    void Start () {
        clone = item;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Instantiate(clone, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void ApplyHeadshotDamage()
    {
        Instantiate(clone, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
