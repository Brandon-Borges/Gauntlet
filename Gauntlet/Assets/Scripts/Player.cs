using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float fireSpeed;
    public int defense;
    public int hp;
    public int score;
    public int potionCount;
    public int keyCount;

    public bool isFiring;
    public bool isCurrentlyFiring;
    public bool friendlyFire;
    public GameObject projectile;
    public Vector3 currentDirection;
    public bool coinSpamPrevent;
    public bool potionSpamPrevent;
    private GameObject referencePotion;

    // Start is called before the first frame update
    void Start()
    {
        referencePotion = GameObject.FindGameObjectWithTag("PotionRef");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthDrain()
    {
        hp--;
    }

    public void quickChange()
    {
        isCurrentlyFiring = false;
    }

    public IEnumerator shoot(Vector2 moveDir)
    {
        Vector3 testForward;
        if (moveDir.x != 0 || moveDir.y != 0) testForward = new Vector3(moveDir.x, 0, moveDir.y);
        else testForward = currentDirection;
        GameObject bullet = Instantiate(projectile, transform.position, projectile.transform.rotation);
        bullet.gameObject.GetComponent<Projectile>().assignShooter(this.gameObject.transform.tag);
        bullet.gameObject.GetComponent<Projectile>().forwardMovement = testForward;
        isFiring = true;
        yield return new WaitForSeconds(fireSpeed);
        isFiring = false;
    }

    public void usePotion()
    {
        if (potionCount > 0)
        {
            potionCount--;
        }
    }

    public void insertCoin()
    {
        if (hp < 3500)
        {
            hp += 700;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
            score += 100;
            keyCount++;
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Door")
        {
            if (keyCount > 0)
            {
                keyCount--;
                //other.gameObject.GetComponent<Door>().unlock();
            }
        }
        if (other.transform.tag == "Potion")
        {
            referencePotion.GetComponent<Potion>().usePotion(this.gameObject.transform.tag);
            potionCount++;
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "Food")
        {
            hp += other.gameObject.GetComponent<Food>().healthRestore;
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Treasure")
        {
            score += 100;
            Destroy(other.gameObject);
        }
    }
}
