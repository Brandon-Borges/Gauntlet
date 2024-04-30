using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Player
{
    private WizardInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new WizardInputs();
        playerInputs.Enable();
        InvokeRepeating("healthDrain", 1f, 1f);
        currentDirection = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector2 MoveVector = playerInputs.Wizard.Move.ReadValue<Vector2>();

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

        if (playerInputs.Wizard.Shoot.ReadValue<float>() > .1f)
        {
            isCurrentlyFiring = true;
            if (!isFiring) StartCoroutine(shoot(MoveVector));
        }
        else Invoke("quickChange", 0.5f);

        if (playerInputs.Wizard.Coin.ReadValue<float>() > .1f)
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

        if (playerInputs.Wizard.Potion.ReadValue<float>() > .1f)
        {
            if (potionSpamPrevent == false)
            {
                usePotion();
                potionSpamPrevent = true;
            }
        }
        else
        {
            potionSpamPrevent = false;
        }
    }
}
