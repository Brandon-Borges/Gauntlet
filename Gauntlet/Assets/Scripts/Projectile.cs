using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 forwardMovement;
    public string playerTag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += forwardMovement * speed * Time.deltaTime;
        if (forwardMovement == new Vector3(0, 0, 0)) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag != playerTag)
        {
            if (other.transform.tag == "Warrior" || other.transform.tag == "Valkyrie" ||
            other.transform.tag == "Wizard" || other.transform.tag == "Elf")
            {
                if (other.transform.tag != playerTag)
                {
                    if (other.gameObject.GetComponent<Player>().friendlyFire == true)
                    {
                        //deal damage
                    }
                }
            }
            if (other.transform.tag == "Food" && other.gameObject.GetComponent<Food>().breakable)
            {
                Destroy(other.gameObject);
            }

            if (other.transform.tag == "Potion" && other.gameObject.GetComponent<Potion>().breakable)
            {
                other.gameObject.GetComponent<Potion>().shotPotion(playerTag);
            }

            Destroy(this.gameObject);
        }
    }
    public void assignShooter(string tag)
    {
        playerTag = tag;
    }
}
