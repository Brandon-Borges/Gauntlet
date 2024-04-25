using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : Player
{
    private ValkyrieInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new ValkyrieInputs();
        playerInputs.Enable();
        InvokeRepeating("healthDrain", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector2 MoveVector = playerInputs.Valkyrie.Move.ReadValue<Vector2>();

        if (MoveVector.x > 0)
        {
            currentDirection = Vector3.right;
            if (!isCurrentlyFiring)
            {
                transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
            }
        }
        if (MoveVector.x < 0)
        {
            currentDirection = Vector3.left;
            if (!isCurrentlyFiring)
            {
                transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
            }
        }
        if (MoveVector.y > 0)
        {
            currentDirection = Vector3.forward;
            if (!isCurrentlyFiring)
            {
                transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
            }
        }
        if (MoveVector.y < 0)
        {
            currentDirection = Vector3.back;
            if (!isCurrentlyFiring)
            {
                transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
            }
        }

        if (playerInputs.Valkyrie.Shoot.ReadValue<float>() > .1f)
        {
            isCurrentlyFiring = true;
            if (!isFiring) StartCoroutine(shoot(MoveVector));
        }
        else isCurrentlyFiring = false;

        if (playerInputs.Valkyrie.Coin.ReadValue<float>() > .1f)
        {
            if (coinSpamPrevent == false)
            {
                insertCoin();
                coinSpamPrevent = true;
            }
        }
        else
        {
            coinSpamPrevent = false;
        }
    }
}
