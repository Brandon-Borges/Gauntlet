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

    // Start is called before the first frame update
    void Start()
    {
        
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
        Vector3 testForward = new Vector3(moveDir.x, 0, moveDir.y);
        GameObject bullet = Instantiate(projectile, transform.position, projectile.transform.rotation);
        /*
        if (moveDir.x > 0 && moveDir.y > 0)
        {
            testForward = (Vector3.right + Vector3.forward);
            //bullet.gameObject.GetComponent<Projectile>().forwardMovement = (Vector3.right + Vector3.forward);
        }
        else if (moveDir.x < 0 && moveDir.y > 0)
        {
            testForward = (Vector3.left + Vector3.forward);
            //bullet.gameObject.GetComponent<Projectile>().forwardMovement = (Vector3.left + Vector3.forward);
        }
        if (moveDir.x > 0 && moveDir.y < 0)
        {
            testForward = (Vector3.right + Vector3.back);
            //bullet.gameObject.GetComponent<Projectile>().forwardMovement = (Vector3.right + Vector3.back);
        }
        else if (moveDir.x < 0 && moveDir.y < 0)
        {
            testForward = (Vector3.left + Vector3.back);
            //bullet.gameObject.GetComponent<Projectile>().forwardMovement = (Vector3.left + Vector3.back);
        }
        */
        bullet.gameObject.GetComponent<Projectile>().forwardMovement = testForward;
        //bullet.gameObject.GetComponent<Projectile>().forwardMovement = this.currentDirection;
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
        if (hp < 4500)
        {
            hp += 700;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Key")
        {
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
        }
    }
}
