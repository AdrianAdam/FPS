using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public GameObject enemy; //zombie
    public float spawnTime = 5f; //time between enemy spawn
    public float time = 0;

    void Start()
    {
        spawnEnemy();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            time = 0;
            spawnEnemy();
        }
    }
    
    public void spawnEnemy()
    {
        Vector3 pos = new Vector3(0, 0, 560);

        Instantiate(enemy, pos, Quaternion.identity);
    }
}
