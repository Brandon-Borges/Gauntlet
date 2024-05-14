using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostGenerator : Generator
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", spawnRate, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 3)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (health == 2)
        {
            this.gameObject.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
        }
        else if (health == 1)
        {
            this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        enemyToSpawn.GetComponent<Enemy>().health = health;

        setSpawnPos();
    }
}
