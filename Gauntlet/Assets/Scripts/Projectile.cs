using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += hero_direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Warrior" || other.transform.tag == "Valkyrie" ||
            other.transform.tag == "Wizard" || other.transform.tag == "Elf")
        {
            if (other.gameObject.GetComponent<Player>().friendlyFire == true)
            {
                //deal damage
            }
        }

        Destroy(this);
    }
}
