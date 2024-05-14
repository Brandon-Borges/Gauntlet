using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherGenerator : Generator
{
    public List<Material> levels;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            GetComponent<Renderer>().material = levels[health - 1];
        }

        enemyToSpawn.GetComponent<Enemy>().health = health;

        setSpawnPos();
    }
}
