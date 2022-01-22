using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class BallAgent : Agent
{
    public Rigidbody rBody;
    public Transform target;
	public float forceMultiplier = 10;

	public Transform[] spawnPositions;

	public GameObject ray;
	Vector3 lastPosition;
	Vector3 currentDirection;

	public void SetRespawnPosition()
    {
		//int pos = spawnPositions.Length;
		//int r = Random.Range(0, pos);


		this.rBody.angularVelocity = Vector3.zero;
		this.rBody.velocity = Vector3.zero;

		// If the Agent fell, zero its momentum
		if (this.transform.localPosition.y < 0)
		{

			//this.transform.localPosition = new Vector3( 0, 0.5f, 0);

		}


		this.transform.position = spawnPositions[1].position;
		this.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

		lastPosition = this.transform.localPosition;
		currentDirection = Vector3.zero;
		ray.transform.rotation = Quaternion.LookRotation(currentDirection);

		
	}
    public void Start()
    {
		
        SetRespawnPosition();
    }
    public override void OnEpisodeBegin()
    {
		
	}
	
	public override void CollectObservations(VectorSensor sensor)
	{
		// Target and Agent positions
		sensor.AddObservation(this.transform.localPosition);
		sensor.AddObservation(target.localPosition);

		// Agent velocity
		sensor.AddObservation(rBody.velocity.x);
		sensor.AddObservation(rBody.velocity.z);
	}

    public  void FixedUpdate()
    {
        currentDirection=(this.transform.localPosition-lastPosition).normalized;
		lastPosition=this.transform.localPosition;

		if(currentDirection!=Vector3.zero)
        {
			ray.transform.rotation = Quaternion.Slerp(ray.transform.rotation, Quaternion.LookRotation(currentDirection), Time.deltaTime * 75);
		}

		if(StepCount>=MaxStep)
        {
			Debug.Log("Max step reached");
			EndEpisode();
        }

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
	{
		// Actions, size = 2
		Vector3 controlSignal = Vector3.zero;
		controlSignal.x = actionBuffers.ContinuousActions[0];
		controlSignal.z = actionBuffers.ContinuousActions[1];
		rBody.AddForce(controlSignal * forceMultiplier);

		// Rewards
		//float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

		// Reached target
		SetReward(-1 / MaxStep);

		if(StepCount>=MaxStep)
        {
			Debug.Log("Max Step Reached");
			SetReward(-1.0f);
			EndEpisode();
        }

		// Fell off platform
		else if (this.transform.localPosition.y < 0)
		{
			SetReward(-1.0f);
			EndEpisode();
		}

		
	}

	public void OnCollisionEnter(Collision collision)
	{
		//Detect trap
		if (collision.gameObject.tag=="trap")
        {
			SetReward(-1.0f);
			EndEpisode();
			//Position is not restarted
        }
		if (collision.gameObject.tag == "Finish")
		{
			Debug.Log("Target Reached");
			SetReward(1.0f);
			EndEpisode();
			//Position is not restarted
		}
		if (collision.gameObject.tag == "wall")
		{
			Debug.Log("Wall detected");
			SetReward(-1.0f);
			EndEpisode();
			//Position is not restarted
		}
	}
	

	public override void Heuristic(in ActionBuffers actionsOut)
	{
		var continuousActionsOut = actionsOut.ContinuousActions;
		continuousActionsOut[0] = Input.GetAxis("Horizontal");
		continuousActionsOut[1] = Input.GetAxis("Vertical");
	}
}


