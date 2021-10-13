using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{

    public Transform target;
    public int maxVelocity;
    public int turnSpeed;
    float stopDistance;

    float freq;
    float updateTime;

    public bool seek;
   
    // Start is called before the first frame update
    void Start()
    {
        maxVelocity = 10;
        turnSpeed = 4;
        stopDistance = 1.0f;

        freq = 0f;
        updateTime = 0.01f;

        seek = false;
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if(freq>updateTime)
        {
            freq -= updateTime;

            if(seek) Seek();

        }
    }

    private void Seek()
    {
        //Seek
        float distance = Vector3.Distance(target.transform.position, transform.position);
        if (distance < stopDistance) return;

        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;//floor level

        Vector3 movement = direction.normalized * maxVelocity;

        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);

        transform.rotation = Quaternion.Slerp(transform.rotation, rotation,Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * maxVelocity * Time.deltaTime;

    }

    void Wander()
    {

    }
}
