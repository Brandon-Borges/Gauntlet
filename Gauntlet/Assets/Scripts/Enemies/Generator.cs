using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public int health;
    public int score = 10;
    public int xOffset;
    public int zOffset;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setSpawnPos()
    {
        xOffset = (Random.Range(0, 2)) * 2;
        zOffset = (Random.Range(0, 2)) * 2;
        if (xOffset == 0) xOffset = -2;
        if (zOffset == 0) zOffset = -2;
    }

    public void spawnEnemy()
    {
        Instantiate(enemyToSpawn, (transform.position + new Vector3(xOffset, 0, zOffset)), enemyToSpawn.transform.rotation);
    }
}
