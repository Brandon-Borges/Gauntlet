using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 forwardMovement;
    public string playerTag;
    public GameObject player;

    public bool canRefresh;

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

        if (playerTag == "Warrior")
        {
            if (new Vector3
                (player.GetComponent<Warrior>().MoveVector.x, 0, 
                player.GetComponent<Warrior>().MoveVector.y) != forwardMovement &&
                player.GetComponent<Warrior>().currentDirection != forwardMovement)
                canRefresh = false;
        }
        else if (playerTag == "Valkyrie")
        {
            if (new Vector3
                (player.GetComponent<Valkyrie>().MoveVector.x, 0,
                player.GetComponent<Valkyrie>().MoveVector.y) != forwardMovement &&
                player.GetComponent<Valkyrie>().currentDirection != forwardMovement)
                canRefresh = false;
        }
        else if (playerTag == "Wizard")
        {
            if (new Vector3
                (player.GetComponent<Wizard>().MoveVector.x, 0,
                player.GetComponent<Wizard>().MoveVector.y) != forwardMovement &&
                player.GetComponent<Wizard>().currentDirection != forwardMovement)
                canRefresh = false;
        }
        else if (playerTag == "Elf")
        {
            if (new Vector3
                (player.GetComponent<Elf>().MoveVector.x, 0,
                player.GetComponent<Elf>().MoveVector.y) != forwardMovement &&
                player.GetComponent<Elf>().currentDirection != forwardMovement)
                canRefresh = false;
        }
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
            if (other.transform.tag == "Door")
            {
                
            }

            if (playerTag == "Warrior")
            {
                if (this.canRefresh) player.GetComponent<Warrior>().isFiring = false;
            }
            else if (playerTag == "Valkyrie")
            {
                if (this.canRefresh) player.GetComponent<Valkyrie>().isFiring = false;
            }
            else if (playerTag == "Wizard")
            {
                if (this.canRefresh) player.GetComponent<Wizard>().isFiring = false;
            }
            else if (playerTag == "Elf")
            {
                if (this.canRefresh) player.GetComponent<Elf>().isFiring = false;
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
        yield return new WaitForSeconds(0.1f);
        if (playerTag == "Warrior")
        {
            yield return new WaitForSeconds(player.GetComponent<Warrior>().fireSpeed - 0.1f);
        }
        else if (playerTag == "Valkyrie")
        {
            yield return new WaitForSeconds(player.GetComponent<Valkyrie>().fireSpeed - 0.1f);
        }
        else if (playerTag == "Wizard")
        {
            yield return new WaitForSeconds(player.GetComponent<Wizard>().fireSpeed - 0.1f);
        }
        else if (playerTag == "Elf")
        {
            yield return new WaitForSeconds(player.GetComponent<Elf>().fireSpeed - 0.5f);
        }
        if (this.isActiveAndEnabled) canRefresh = false;
    }
}
