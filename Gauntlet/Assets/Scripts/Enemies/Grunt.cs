using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grunt : Enemy
{
    public List<Material> levels;
    public int damage;
    public float speed;
    public bool attacking;
    public float cooldown = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        AssignHeroes();
        attacking = false;
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

            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed);
        }

        if (health == 3)
        {
            damage = 10;
        }
        else if (health == 2)
        {
            damage = 8;
        }
        else if (health == 1)
        {
            damage = 5;
        }

        if (Mathf.Approximately(targetsDist, 1f) || targetsDist <= 1f)
        {
            speed = 0;
            if (!attacking) StartCoroutine(attackTarget());
        }
        else
        {
            speed = 0.005f;
        }
    }

    public IEnumerator attackTarget()
    {
        attacking = true;
        //target's health goes down by "damage"
        if (target.gameObject == warrior) target.gameObject.GetComponent<Warrior>().hp -= damage;
        else if (target.gameObject == valkyrie) target.gameObject.GetComponent<Valkyrie>().hp -= damage;
        else if (target.gameObject == wizard) target.gameObject.GetComponent<Wizard>().hp -= damage;
        else if (target.gameObject == elf) target.gameObject.GetComponent<Elf>().hp -= damage;
        yield return new WaitForSeconds(cooldown);
        attacking = false;
    }
}
