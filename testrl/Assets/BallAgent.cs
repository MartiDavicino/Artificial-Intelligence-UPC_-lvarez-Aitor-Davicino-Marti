﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class BallAgent : Agent
{
    public Rigidbody rBody;
    public Transform Target;
	public float forceMultiplier = 10;

	public Transform[] spawnPositions;

    public void SetRespawnPosition()
    {
		int pos = spawnPositions.Length;
		int r = Random.Range(0, pos);

		gameObject.transform.position = spawnPositions[r].position;
    }
    public override void OnEpisodeBegin()
    {
       // If the Agent fell, zero its momentum
        if (this.transform.localPosition.y < 0)
        {
            this.rBody.angularVelocity = Vector3.zero;
            this.rBody.velocity = Vector3.zero;
            this.transform.localPosition = new Vector3( 0, 0.5f, 0);
        }

        // Move the target to a new spot
        Target.localPosition = new Vector3(Random.value * 8 - 4,
                                           0.5f,
                                           Random.value * 8 - 4);
    }
	
	public override void CollectObservations(VectorSensor sensor)
	{
		// Target and Agent positions
		sensor.AddObservation(Target.localPosition);
		sensor.AddObservation(this.transform.localPosition);

		// Agent velocity
		sensor.AddObservation(rBody.velocity.x);
		sensor.AddObservation(rBody.velocity.z);
	}
	
	public override void OnActionReceived(ActionBuffers actionBuffers)
	{
		// Actions, size = 2
		Vector3 controlSignal = Vector3.zero;
		controlSignal.x = actionBuffers.ContinuousActions[0];
		controlSignal.z = actionBuffers.ContinuousActions[1];
		rBody.AddForce(controlSignal * forceMultiplier);

		// Rewards
		float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

		// Reached target
		if (distanceToTarget < 1.42f)
		{
			SetReward(1.0f);
			EndEpisode();
			SetRespawnPosition();
		}

		// Fell off platform
		else if (this.transform.localPosition.y < 0)
		{
			EndEpisode();
			SetRespawnPosition();
		}

		//Detect trap
		
	}

	public void OnCollisionEnter(Collision collision)
	{

		if(collision.gameObject.tag=="trap")
        {
			EndEpisode();
			//Position is not restarted
			SetRespawnPosition();
        }
	}
	

	public override void Heuristic(in ActionBuffers actionsOut)
	{
		var continuousActionsOut = actionsOut.ContinuousActions;
		continuousActionsOut[0] = Input.GetAxis("Horizontal");
		continuousActionsOut[1] = Input.GetAxis("Vertical");
	}
}


