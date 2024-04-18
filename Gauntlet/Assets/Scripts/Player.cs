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

    public IEnumerator shoot()
    {
        GameObject bullet = Instantiate(projectile, transform.position, projectile.transform.rotation);
        bullet.transform.forward = this.transform.forward;
        isFiring = true;
        yield return new WaitForSeconds(fireSpeed);
        isFiring = false;
    }
}
