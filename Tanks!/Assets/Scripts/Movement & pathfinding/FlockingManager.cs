using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{
    FlockingManager myManager;

    [Header("General")]
    public GameObject beePrefab01;
    public GameObject beePrefab02;
    public GameObject beePrefab03;

    GameObject[] beePrefab = new GameObject[2];
    
    public int numBees;
    public GameObject[] allBees;
    public Vector3 swimLimits;
    bool bounded, randomize, followLeader;
    public GameObject leader;

    [Header("Fish Settings")]
    [Range(1f,5f)]
    public float minSpeed;
    [Range(3f, 8f)]
    public float maxSpeed;
    [Range(.5f, 5f)]
    public float neighbourDistance;
    [Range(.1f, 60f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        myManager = GetComponent<FlockingManager>();

        //beePrefab[0] = beePrefab01;
        //beePrefab[1] = beePrefab01;
        //beePrefab[2] = beePrefab01;

        numBees = 20;
        swimLimits = new Vector3(7, 5, 7);
        bounded = true;
        randomize = false;
        followLeader = false;

        allBees = new GameObject[numBees];
        float offPos = 3.5f;
        float offRot = 3.5f;
        for (int i = 0; i < numBees; ++i)
        {
            Vector3 posOffset = new Vector3(Random.Range(-offPos, offPos), Random.Range(-offPos, offPos), Random.Range(-offPos, offPos));
            Vector3 pos = this.transform.position + posOffset;
            Vector3 randomDirection=new Vector3(Random.Range(-offRot, offRot), Random.Range(-offRot, offRot), Random.Range(-offRot, offRot));

            //int r = Random.Range(0, 3);
 
            allBees[i] = (GameObject)Instantiate(beePrefab01, pos, Quaternion.LookRotation(randomDirection));
            allBees[i].GetComponent<FlockingManager>().myManager = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
