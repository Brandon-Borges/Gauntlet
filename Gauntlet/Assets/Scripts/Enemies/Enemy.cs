using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int shootScore;
    public int potionScore;
    public int fightScore;
    public bool isFightable;
    public int health;

    private GameObject warrior;
    private GameObject valkyrie;
    private GameObject wizard;
    private GameObject elf;

    public Transform target;
    public float targetsDist;
    float warriorDist;
    float valkDist;
    float wizardDist;
    float elfDist;

    // Start is called before the first frame update
    void Start()
    {
        AssignHeroes();
    }

    // Update is called once per frame
    void Update()
    {
        FindClosest();

        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 1);
    }

    public void FindClosest()
    {
        if (warrior != null) warriorDist = Vector3.Distance(transform.position, warrior.transform.position);
        else warriorDist = 0;
        if (valkyrie != null) valkDist = Vector3.Distance(transform.position, valkyrie.transform.position);
        else valkDist = 0;
        if (wizard != null) wizardDist = Vector3.Distance(transform.position, wizard.transform.position);
        else wizardDist = 0;
        if (elf != null) elfDist = Vector3.Distance(transform.position, elf.transform.position);
        else elfDist = 0;

        assignTarget(warrior, valkyrie, warriorDist, valkDist);
        assignTarget(target.gameObject, wizard, targetsDist, wizardDist);
        assignTarget(target.gameObject, elf, targetsDist, elfDist);
    }

    public void assignTarget(GameObject lhs, GameObject rhs, float lhsDist, float rhsDist)
    {
        if (lhs == null)
        {
            target = rhs.GetComponent<Transform>();
            targetsDist = rhsDist;
        }
        else if (rhs == null)
        {
            target = lhs.GetComponent<Transform>();
            targetsDist = lhsDist;
        }
        else
        {
            if (lhsDist < rhsDist)
            {
                target = lhs.GetComponent<Transform>();
                targetsDist = lhsDist;
            }
            else
            {
                target = rhs.GetComponent<Transform>();
                targetsDist = rhsDist;
            }
        }
    }

    public void AssignHeroes()
    {
        warrior = GameObject.FindGameObjectWithTag("Warrior");
        valkyrie = GameObject.FindGameObjectWithTag("Valkyrie");
        wizard = GameObject.FindGameObjectWithTag("Wizard");
        elf = GameObject.FindGameObjectWithTag("Elf");
    }
}
