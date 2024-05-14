using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valkyrie : Player
{
    private ValkyrieInputs playerInputs;
    public Vector2 MoveVector;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new ValkyrieInputs();
        playerInputs.Enable();
        InvokeRepeating("healthDrain", 1f, 1f);
		InvokeRepeating("UpdateInfo", 1f, 1f);
		currentDirection = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        //if (!isFiring) StopCoroutine(shoot(MoveVector));
    }

    public void FixedUpdate()
    {
        MoveVector = playerInputs.Valkyrie.Move.ReadValue<Vector2>();


		if (MoveVector.x > 0)
		{
			currentDirection = Vector3.right;
			if (!isCurrentlyFiring)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, Vector3.right, out hit))
				{
					if (hit.rigidbody.tag == "Wall" && hit.distance <= .5)
					{
						return;
					}
					else
					{
						transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
					}
				}

				//transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
			}
		}
		if (MoveVector.x < 0)
		{
			currentDirection = Vector3.left;
			if (!isCurrentlyFiring)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, Vector3.left, out hit))
				{
					if (hit.rigidbody.tag == "Wall" && hit.distance <= .5)
					{
						return;
					}
					else
					{
						transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
					}
				}

			}
		}
		if (MoveVector.y > 0)
		{
			currentDirection = Vector3.forward;
			if (!isCurrentlyFiring)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, Vector3.forward, out hit))
				{
					if (hit.rigidbody.tag == "Wall" && hit.distance <= .5)
					{
						return;
					}
					else
					{
						transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
					}
				}
			}
		}
		if (MoveVector.y < 0)
		{
			currentDirection = Vector3.back;
			if (!isCurrentlyFiring)
			{
				RaycastHit hit;
				if (Physics.Raycast(transform.position, Vector3.back, out hit))
				{
					if (hit.rigidbody.tag == "Wall" && hit.distance <= .5)
					{
						return;
					}
					else
					{
						transform.position += currentDirection.normalized * moveSpeed * Time.deltaTime;
					}
				}

			}
		}

        if (playerInputs.Valkyrie.Shoot.ReadValue<float>() > .1f)
        {
            isCurrentlyFiring = true;
            if (!isFiring) StartCoroutine(shoot(MoveVector));
        }
        else Invoke("quickChange", 0.5f);

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

        if (playerInputs.Valkyrie.Potion.ReadValue<float>() > .1f)
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
	void UpdateInfo()
	{
		UIManager.Instance.updateHealthText(1, hp);
		UIManager.Instance.updateScoreText(1, score);

	}
}
