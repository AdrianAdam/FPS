using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {

    [SerializeField] public float health = 100; //to view in the editor
    public GameObject healthDisplay;

    void Start()
    {
        healthDisplay.GetComponent<Text>().text = health + "/ 100";
    }

    void Update()
    {
        healthDisplay.GetComponent<Text>().text = health + "/100";
    }

    public void applyDamageToPlayer(float damage)
    {
   
        health -= damage;
        healthDisplay.GetComponent<Text>().text = health + "/ 100";

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void addHealth()
    {
        if (health >= 100)
            return;
        else
        {
            health += 10;
        }

        if (health > 100)
        {
            health = 100;
        }
    }
}
