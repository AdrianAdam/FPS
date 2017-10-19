using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAttack : MonoBehaviour {
    public Transform target; //the player

    public float damage = 0.00001f; //damage of the zombie
    private float lastAttackTime; //when was the last attack
    public float attackDelay = 7000f; //delay between attacks
    private float distanceToPlayer; //distance between zombie and player
    private float attackRange = 1.4f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        distanceToPlayer = Vector3.Distance(transform.position, target.position);
     
        if (distanceToPlayer < attackRange)
        {
           
            if (Time.time > lastAttackTime + attackDelay)
            {
                GameObject.Find("FPSController").transform.GetComponent<HealthController>().applyDamageToPlayer(damage);
                lastAttackTime = Time.time + Time.deltaTime;
            }
        }
	}
}
