using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Player
{
    private ElfInputs playerInputs;

    // Start is called before the first frame update
    void Start()
    {
        playerInputs = new ElfInputs();
        playerInputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
        Vector2 MoveVector = playerInputs.Elf.Move.ReadValue<Vector2>();

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
    }
}
