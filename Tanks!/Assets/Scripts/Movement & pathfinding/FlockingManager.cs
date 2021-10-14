using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockingManager : MonoBehaviour
{

    [Header("General")]
    public GameObject beePrefab01;
    public GameObject beePrefab02;
    public GameObject beePrefab03;

    GameObject[] beePrefab;
    
    int numBees;
    GameObject[] allBees;
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
        beePrefab = new GameObject[3] { beePrefab01, beePrefab02, beePrefab03 };

        numBees = 40;
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

            int r = Random.Range(0, 3);
            allBees[i] = (GameObject)Instantiate(beePrefab[r], pos, Quaternion.LookRotation(randomDirection));
            //allBees[i].GetComponent<FlockingManager>().myManager = this;



            Animator animator = allBees[i].GetComponent<Animator>();
            animator.Play("Idle", -1,Random.Range(0f,.9f));



        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
