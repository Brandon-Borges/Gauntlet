using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    public List<Material> levels;

    // Start is called before the first frame update
    void Start()
    {
        AssignHeroes();
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
            FindClosest();

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.005f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Warrior" || other.transform.tag == "Valkyrie" ||
            other.transform.tag == "Wizard" || other.transform.tag == "Elf")
        {
            Destroy(this.gameObject);
        }

        if (other.transform.tag == "Door")
        {
            for (int i = 0; i <= GameObject.FindGameObjectsWithTag("Door").Length; i++)
            {
                //if (other.gameObject == i's gameObject)
            }
        }
    }

    public void DamageHero(GameObject player)
    {
        if (health == 3)
        {
            player.GetComponent<Player>().hp -= 30;
        }
        else if (health == 2)
        {
            player.GetComponent<Player>().hp -= 20;
        }
        else if (health == 1)
        {
            player.GetComponent<Player>().hp -= 10;
        }
        Destroy(this.gameObject);
    }
}
