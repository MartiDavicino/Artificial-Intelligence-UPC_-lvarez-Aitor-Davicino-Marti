using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public bool seek = false;
    public bool reload = false;

    public Transform target;
    public GameObject pointer;
    public GameObject reloadPlat;
    public float turnSpeed;
    public float maxDistance;
    public float maxSpeed;
    public float acceleration;
    public float stopDistance;
    public float turnAcceleration;
    public float maxTurnSpeed;
    public float maxVelocity;
    public float movSpeed;
    public float minDistance;

    Vector3 movement = Vector3.zero;
    Quaternion rotation;
    float freq = 0f;
    public float updateFreq;

    public Shooting shoot;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            target = gameObject.transform;

        turnSpeed = 20f;
        maxDistance = 2f;
        maxSpeed = 1;
        acceleration = 1f;
        stopDistance = 2f;
        turnAcceleration = 1f;
        maxTurnSpeed = 40f;
        maxVelocity = 2f;
        movSpeed = 2f;
        updateFreq=8.0f;
        minDistance = 15.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckReload();
        if(reload){
            Seek(reloadPlat.transform);
        }
        else{
            CheckSeek(target);
            if(seek){
                Seek(target);
            };
        }
        freq += Time.deltaTime;
        if (freq > updateFreq)
        {
            
            freq -= updateFreq;
            if (!seek && !reload)
            {
                Wander();
            } 
            
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * turnSpeed);
        transform.position += transform.forward.normalized * maxVelocity * Time.deltaTime;


    }

     void Seek(Transform tar)
    {
        Vector3 direction = tar.transform.position - transform.position;
        direction.y = 0f;
        movement = direction.normalized * acceleration;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(movement.x, movement.z);
        rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }

    void CheckSeek(Transform tar)
    {
        if(minDistance>= Vector3.Distance(tar.transform.position,transform.position))
        {
            seek = true;
        }
        else{
            seek = false;
        }
    }
    void CheckReload()
    {
        if(shoot.hasNoBullets) reload = true;
        else reload = false;
    }

     void Wander()
    {
        float radius = 2f;
        float offset = 3f;
        Vector3 localTarget = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        localTarget.Normalize();
        localTarget *= radius;
        localTarget += new Vector3(0, 0, offset);
        Vector3 worldTarget = transform.TransformPoint(localTarget);
        worldTarget.y = 0f;  //Uncommnet for 2D wander
        pointer.transform.position = worldTarget;
        Seek(pointer.transform);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
