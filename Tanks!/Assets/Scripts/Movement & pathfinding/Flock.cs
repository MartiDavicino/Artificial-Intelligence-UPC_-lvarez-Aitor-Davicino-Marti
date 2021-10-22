using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour
{
    public FlockingManager myManager;
    public bool leader = false;
    public float speed = 2;
    private Vector3 direction;
    private float timePassed = 0f;


    // Start is called before the first frame update
    void Start()
    {
        if (myManager == null) 
        {
            myManager = GameObject.Find("Flocking Manager").GetComponent<FlockingManager>();
            Debug.LogWarning("Flocking manager null...");
        } 

        if (!leader)
            timePassed = Random.Range(0, myManager.deltaCalculate);
        else
            timePassed = myManager.leaderDeltaCalculate;

        direction = myManager.RandomOrientation(-1f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (DetectCollision())
        {
            Debug.Log("Change direction needed");

            //It's not updated because the UpdateFlock is not called in all frames(?)
            //Maybe set the timePassed inside ChangeDirection()
            ChangeDirection();
        }
       
        else
        {
            UpdateFlock();

        }


    }

    void UpdateFlock()
    {
        timePassed += Time.deltaTime;
        if (!leader&& timePassed >= myManager.deltaCalculate)
        {
            if (!DetectCollision())
            {
                direction = ((Cohesion() + Align() + Separate()).normalized + myManager.RandomOrientation(-1f, 1) * 1) * speed;
                direction += Leader();
                direction.Normalize();
                timePassed = 0;
            }
        }

        else if (leader && timePassed >= myManager.leaderDeltaCalculate)
        {
            speed = myManager.leaderSpeed;
            direction += myManager.RandomOrientation(-1f,1f) * myManager.leaderRotationSpeed;
            direction.Normalize();
            timePassed = 0;
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);
        transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag=="Boundaries")
        {
            //ChangeDirection();

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Obstacles")
        {
            //ChangeDirection();
        }
    }

    private void OnTriggerStay(Collider other)
    {
      
    }

    void ChangeDirection()
    {
        

        //Debug.Log("Actual rot : " + transform.rotation + "Inverse rot : " + inverseRot);

        //inverseRot -= myManager.RandomOrientation();
        
        direction = myManager.RandomOrientation(-1f,1f);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), myManager.rotationSpeed * Time.deltaTime);

        timePassed = myManager.deltaCalculate;

    }

    bool DetectCollision()
    {
        bool ret = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 2))
        {
            
            if (hit.collider.tag == "Boundaries" || hit.collider.tag=="Obstacles")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                Debug.Log("Hit boundaries or obstacles");
                ret = true;
            }
            //if (hit.collider.tag == "Player")
            //{
            //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            //    Debug.Log("Hit bee");
            //    //ret = true;
            //}

        }
        return ret;
    }
    Vector3 Cohesion()
    {
        Vector3 cohesion = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allBees)
        {
            if (go != this.gameObject)
            {
                
                float distance = Vector3.Distance(go.transform.position, this.transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    cohesion += go.transform.position;
                    num++;
                }
            }
        }
        if (num > 0)
            cohesion = (cohesion / num - transform.position).normalized * speed;


        return cohesion;
    }

    Vector3 Align()
    {
        Vector3 align = Vector3.zero;
        int num = 0;
        foreach (GameObject go in myManager.allBees)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= myManager.neighbourDistance)
                {
                    align += go.GetComponent<Flock>().direction;
                    num++;
                }
            }
        }
        if (num > 0)
        {
            align /= num;
            speed = Mathf.Clamp(align.magnitude, myManager.minSpeed, myManager.maxSpeed);
        }

        return align;
    }

    Vector3 Separate()
    {
        Vector3 separation = Vector3.zero;
        foreach (GameObject go in myManager.allBees)
        {
            if (go != this.gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, transform.position);
                if (distance <= myManager.neighbourDistance)
                    separation -= (transform.position - go.transform.position) / (distance * distance);
            }
        }

        return separation;
    }

    Vector3 Leader()
    {
        Vector3 leaderPos = Vector3.zero;

        if (leader) return leaderPos;
            
        foreach (GameObject go in myManager.allBees)
        {
            Flock f = go.GetComponent<Flock>();
            if (f.leader)
            {
                leaderPos = this.transform.position - f.transform.position;
            }
        }

        return -leaderPos;
    }
}
