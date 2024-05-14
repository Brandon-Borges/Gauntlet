using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float fireSpeed;
    [Tooltip("Enter a value between 0 and 1 to determine the percentage of damage reduced by the hero.")]
    public float defense;
    public int hp;
    public int score;
    public int projectileDamage;
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
    public float test;

    // Start is called before the first frame update
    void Start()
    {
        referencePotion = GameObject.FindGameObjectWithTag("PotionRef");
        currentDirection = new Vector3(0, 0, -1);
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
        test = 0;
        isFiring = true;
        Vector3 testForward;
        if (moveDir.x != 0 || moveDir.y != 0) testForward = new Vector3(moveDir.x, 0, moveDir.y);
        else testForward = currentDirection;
        GameObject bullet = Instantiate(projectile, transform.position, projectile.transform.rotation);
        bullet.gameObject.GetComponent<Projectile>().assignShooter(this.gameObject.transform.tag);
        bullet.gameObject.GetComponent<Projectile>().forwardMovement = testForward;
        bullet.gameObject.GetComponent<Projectile>().StartCoroutine
            (bullet.gameObject.GetComponent<Projectile>().activationTimer());
        //yield return new WaitForSeconds(fireSpeed);
        while (test < fireSpeed) 
        {
            if (isFiring == false)
            {
                //isFiring = false;
                //yield break;
                test = 30;
            }
            else
            {
                yield return new WaitForSeconds(0.05f);
                test += 0.05f;
            }
        }
        test = 0;
        isFiring = false;
    }

    public void usePotion()
    {
        if (potionCount > 0)
        {
            potionCount--;
            referencePotion.GetComponent<Potion>().usePotion(this.gameObject.transform.tag);
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
        if (other.transform.tag == "Jewels")
        {
            score += 500;
            Destroy(other.gameObject);
        }
        if (other.transform.tag == "Ghost")
        {
            other.gameObject.GetComponent<Ghost>().DamageHero(this.gameObject);
        }
    }
}
