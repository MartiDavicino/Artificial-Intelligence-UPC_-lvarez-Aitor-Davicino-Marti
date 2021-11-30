using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    //ENEMY DETECTION VARIABLES
    public float detectionRange = 20f; //maximum to detect enemies
    public float distance_to_enemy; //actual distance to enemy
    public bool enemy_detected = false;

    public GameObject target; //enemy tank
    public GameObject turret; //tank turret
    public Rigidbody bullet; //bullet we will shoot
    public Transform fireTransform; //place where we spawn the bullets
    [HideInInspector]
    public Transform reloadPlace; //place where you reload

    public AudioSource shootingAudio;
    public AudioClip chargingClip;
    public AudioClip fireClip;

    //PARABOLIC SHOT VARIABLES
    public float speed = 20f; //bullet valocity
    public float gravity = Physics.gravity.y;  //gravity
    public float x; //distance from tank to target
    public float y; //enemy height
    public float angleSin; //angle before doing Mathf.atan
    public float shootingAngle; //shooting angle

    public float reloadTimer = 2f;
    public bool reloading=true;

    public int numBullets = 3;
    public bool hasNoBullets = false;

    // Start is called before the first frame update
    void Start()
    {
        reloadPlace = GameObject.Find("Reload Place").transform;
        reloading = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (reloading) Reload();

    }

    public void Aim()
    {
        DetectEnemy();

        x = Vector3.Distance(target.transform.position, turret.transform.position);

        y = target.transform.position.y;

        //PARABOLIC SHOT FORMULA USED --> angle = (Mathf.Asin((g * x) / (v * v))/(2)

        float part1 = Mathf.Asin((gravity * x) / (speed * speed));
        angleSin = part1 / 2;
        shootingAngle = Mathf.Asin(angleSin) * Mathf.Rad2Deg;

        //rotate the turret if target is active
        if (target.activeSelf)
        {
            turret.transform.LookAt(target.transform);
            turret.transform.Rotate(turret.transform.right, shootingAngle, Space.World);
        }
        else
        {
            if (360 - turret.transform.rotation.eulerAngles.y >= 1)
                turret.transform.Rotate(0, 1, 0);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Fire();
        //}

        //if (!reloading && enemy_detected)
        //{
        //    if (target.activeSelf)
        //        Fire();
        //}

        //if (reloading)
        //{
        //    Reload();
        //}

        if (numBullets <= 0)
        {
            hasNoBullets = true;
        }

        else if (numBullets > 0)
        {
            hasNoBullets = false;
        }

        if (Vector3.Distance(transform.position, reloadPlace.position) <= 5.0f)
        {
            numBullets = 3;
        }
    }
    public void Fire()
    {
        if (numBullets > 0 && enemy_detected && !reloading)
        {
            Rigidbody new_bullet = Instantiate(bullet, fireTransform.position, Quaternion.identity);
            new_bullet.transform.LookAt(target.transform);
            new_bullet.velocity = turret.transform.forward * speed*0.9f;

            shootingAudio.clip = fireClip;
            shootingAudio.Play();

            numBullets--;

            reloading = true;
        }

    }

    public void Reload()
    {
        reloadTimer -= Time.deltaTime;
        if (reloadTimer <= 0)
        {
            reloading = false;
            reloadTimer = 2;
        }
    }

    void DetectEnemy()
    {
        distance_to_enemy = Vector3.Distance(target.transform.position, transform.position);
        if (distance_to_enemy <= detectionRange)
        {
            enemy_detected = true;
        }
        else
        {
            enemy_detected = false;
        }
    }

    public bool HasNOBullets()
    {
        return hasNoBullets;
    }

    public bool IsEnemyClose()
    {
        return enemy_detected;
    }

    public bool IsEnemyFar()
    {
        bool enemy_far;

        enemy_far = !enemy_detected;

        return enemy_far;
    }
}
