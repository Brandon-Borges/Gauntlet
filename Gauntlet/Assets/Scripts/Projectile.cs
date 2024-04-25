using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 forwardMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += forwardMovement * speed * Time.deltaTime;
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
        if (other.transform.tag == "Food" && other.gameObject.GetComponent<Food>().breakable)
        {
            Destroy(other.gameObject);
        }

        Destroy(this.gameObject);
    }
}
