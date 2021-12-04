using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankSeek : MonoBehaviour
{
    //vector3 target points
    public Transform enemy;

    float distanceToEnemy;

    private NavMeshAgent agent;
    private NavMeshHit hit;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.destination = enemy.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position, enemy.position, Color.red);
        agent.destination = enemy.position;

    }

    //Check if Nav Mesh is walkable
    bool CheckIfWalkable(Vector3 wolrd_target)
    {
        if (NavMesh.Raycast(transform.position, enemy.position, out hit, NavMesh.AllAreas))
            return true;
        else return false;
    }

}