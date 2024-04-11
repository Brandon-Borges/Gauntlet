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

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("healthDrain", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void healthDrain()
    {
        hp--;
    }
}
