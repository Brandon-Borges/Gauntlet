using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool breakable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void usePotion(string tag)
    {
        //logic to clear on-screen enemies
    }
    
    public void shotPotion()
    {
        usePotion("Warrior");
        Destroy(this.gameObject);
    }
}
