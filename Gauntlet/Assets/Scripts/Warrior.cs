using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Player
{
    private WarriorInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new WarriorInputs();
        playerInputs.Enable();
        InvokeRepeating("healthDrain", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector2 MoveVector = playerInputs.Warrior.Move.ReadValue<Vector2>();

        if (MoveVector.x > 0)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        if (MoveVector.x < 0)
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (MoveVector.y > 0)
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (MoveVector.y < 0)
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }

        if (playerInputs.Warrior.Shoot.ReadValue<float>() > .1f) {
            if (!isFiring) StartCoroutine(shoot());
        }
    }
}
