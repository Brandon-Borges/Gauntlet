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

    public IEnumerator shoot()
    {
        //shoot projectile
        isFiring = false;
        yield return new WaitForSeconds(fireSpeed);
        isFiring = true;
    }
}
