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
    public GameObject[] allBees;
    public Vector3 flyLimits;
    bool bounded, randomize, followLeader;
    public GameObject leader;

    //From Oscar's script
    [HideInInspector]
    public float leaderDeltaCalculate = 10f;
    public float deltaCalculate = .5f;
    public float leaderSpeed = 1;
    public float leaderRotationSpeed = 0.1f;

    [Header("Fish Settings")]
    [Range(1f, 5f)]
    public float minSpeed;
    [Range(3f, 8f)]
    public float maxSpeed;
    [Range(2.5f, 50f)]
    public float neighbourDistance;
    [Range(.1f, 60f)]
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        minSpeed = 3f;
        maxSpeed = 5f;
        neighbourDistance = 15f;
        rotationSpeed = 30f;

        beePrefab = new GameObject[3] { beePrefab01, beePrefab02, beePrefab03 };

        numBees =30;
        flyLimits = new Vector3(7, 5, 7);
        bounded = true;
        randomize = false;
        followLeader = false;

        allBees = new GameObject[numBees];
        
        for (int i = 0; i < numBees; ++i)
        {
            Vector3 posOffset = RandomPosition();
            Vector3 pos = this.transform.position + posOffset;
            Vector3 randomDirection = RandomOrientation(-1f,1f);

            int r = Random.Range(0, 2); 
            allBees[i] = (GameObject)Instantiate(beePrefab[r], pos, Quaternion.LookRotation(randomDirection));



            if (i == 0 && followLeader)
            {
                allBees[i] = (GameObject)Instantiate(beePrefab[2], pos, Quaternion.LookRotation(randomDirection));
                allBees[i].GetComponent<Flock>().leader = true;
                allBees[i].GetComponent<MovementBehaviour>().pointer = GameObject.Find("Pointer");
                allBees[i].GetComponent<Flock>().speed *= 2f;
            }


            //Animation
            Animator animator = allBees[i].GetComponent<Animator>();
            animator.Play("Idle", -1,Random.Range(0f,.9f));


            allBees[i].GetComponent<Flock>().myManager = this;
        }
    }

    public Vector3 RandomPosition()
    {
        Vector3 pos;
        pos.x = Random.Range(0, flyLimits.x);
        pos.y = Random.Range(0, flyLimits.y);
        pos.z = Random.Range(0, flyLimits.z);
        return pos;
    }
    public Vector3 RandomOrientation(float min,float max)
    {
        Vector3 orientation;
     
        orientation.x = Random.Range(min,max);
        orientation.y = Random.Range(min,max);
        orientation.z = Random.Range(min,max);
        orientation.Normalize();
        return orientation;
    }
    public Vector3 InverseDirection(Vector3 dir)
    {
        Vector3 inv;
        inv.x = -dir.x;
        inv.y = -dir.y;
        inv.z = -dir.z;
        return inv;
    }
}
