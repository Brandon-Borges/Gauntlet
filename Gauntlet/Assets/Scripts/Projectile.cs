using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 forwardMovement;
    public string playerTag;
    public GameObject player;

    bool canRefresh;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag(playerTag);
        canRefresh = true;
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
                        other.gameObject.GetComponent<Player>().hp -=
                            player.gameObject.GetComponent<Player>().projectileDamage;
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

            if (other.transform.tag == "Ghost")
            {
                other.gameObject.GetComponent<Ghost>().health -= player.GetComponent<Player>().projectileDamage;
            }
            if (other.transform.tag == "Grunt")
            {
                other.gameObject.GetComponent<Grunt>().health -= player.GetComponent<Player>().projectileDamage;
            }
            if (other.transform.tag == "Generator")
            {
                other.gameObject.GetComponent<Generator>().health -= player.GetComponent<Player>().projectileDamage;
            }

            if (playerTag == "Warrior")
            {
                if (canRefresh) player.GetComponent<Warrior>().isFiring = false;
            }
            else if (playerTag == "Valkyrie")
            {
                if (canRefresh) player.GetComponent<Valkyrie>().isFiring = false;
            }
            else if (playerTag == "Wizard")
            {
                if (canRefresh) player.GetComponent<Wizard>().isFiring = false;
            }
            else if (playerTag == "Elf")
            {
                if (canRefresh) player.GetComponent<Elf>().isFiring = false;
            }
            Destroy(this.gameObject);
        }
    }
    public void assignShooter(string tag)
    {
        playerTag = tag;
    }

    public IEnumerator activationTimer()
    {
        if (playerTag == "Warrior")
        {
            yield return new WaitForSeconds(player.GetComponent<Warrior>().fireSpeed);
        }
        else if (playerTag == "Valkyrie")
        {
            yield return new WaitForSeconds(player.GetComponent<Valkyrie>().fireSpeed);
        }
        else if (playerTag == "Wizard")
        {
            yield return new WaitForSeconds(player.GetComponent<Wizard>().fireSpeed);
        }
        else if (playerTag == "Elf")
        {
            yield return new WaitForSeconds(player.GetComponent<Elf>().fireSpeed);
        }
        canRefresh = false;
    }
}
