using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public bool seek = false;
    public bool wander = false;


    public Transform target;
    public float turnSpeed = 2f;
    public float maxDistance = 2f;
    public float maxSpeed = 2f;
    public float acceleration = 0f;
    public float stopDistance = 0f;
    public float turnAcceleration = 0f;
    public float maxTurnSpeed = 0f;
    public float maxVelocity = 2f;
    public float movSpeed = 0f;

    Vector3 movement = Vector3.zero;
    Quaternion rotation;
    float freq = 0f;
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        freq += Time.deltaTime;
        if (freq > 0.5)
        {
            freq -= 0.5f;
            Seek();
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * maxVelocity *Time.deltaTime;
        
        if(seek)Seek();   
        // if(wander)Wander();
    }

     void Seek()
    {
        Vector3 direction = target.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    //  void Wander()
    // {
    //     float radius = 2f;
    //     float offset = 3f;
    //     Vector3 localTarget = new Vector3(Random.Range(-1.0f, 1.0f), 0,Random.Range(-1.0f, 1.0f));
    //     localTarget.Normalize();
    //     localTarget *= radius;
    //     localTarget += new Vector3(0, 0, offset);
    //     Vector3 worldTarget = transform.TransformPoint(localTarget);
    //     worldTarget.y = 0f;
    //     Seek(worldTarget);
    // }  

}
