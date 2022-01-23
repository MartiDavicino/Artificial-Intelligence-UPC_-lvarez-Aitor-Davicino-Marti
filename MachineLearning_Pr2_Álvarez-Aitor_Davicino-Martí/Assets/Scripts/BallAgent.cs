using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class BallAgent : Agent
{
	public Rigidbody rBody;
	public Transform Target;
	public float speed = 5;
	public GameObject sensor;

	private Vector2[] positions;
	private int randomOff;

	Vector3 lastPosition;
	Vector3 currentDirection;
    public void Start()
	{
		Debug.Log("Started Simulator");
		positions = new Vector2[3];

		positions[0] = new Vector2(3, 3);
		positions[0] = new Vector2(-3,-3);
		positions[0] = new Vector2(1, -1);

		randomOff = 5;
	}
	public override void OnEpisodeBegin()
	{
		this.rBody.angularVelocity = Vector3.zero;
		this.rBody.velocity = Vector3.zero;


		int r=Random.Range(0, 3);
		Vector2 newPos=new Vector2(positions[r].x, positions[r].y);

		this.transform.localPosition = new Vector3(newPos.x * randomOff, 1.5f, newPos.y * randomOff);

		this.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

		lastPosition = this.transform.localPosition;
		currentDirection = Vector3.zero;
		sensor.transform.rotation = Quaternion.LookRotation(currentDirection);
	}

	public override void CollectObservations(VectorSensor sensor)
	{
        // Agent positions
        sensor.AddObservation(this.transform.localPosition);
		sensor.AddObservation(Target.localPosition);

		// Agent velocity
		sensor.AddObservation(rBody.velocity.x);
		sensor.AddObservation(rBody.velocity.z);
	}

	public void FixedUpdate()
	{
		currentDirection = (this.transform.localPosition - lastPosition).normalized;
		lastPosition = this.transform.localPosition;
		if (currentDirection != Vector3.zero)
		{
			sensor.transform.rotation = Quaternion.Slerp(sensor.transform.rotation, Quaternion.LookRotation(currentDirection), Time.deltaTime * 75);
        }

		if (StepCount >= MaxStep)
		{
			Debug.Log("Max Step Reached");
			EndEpisode();
		}
	}

	public override void OnActionReceived(ActionBuffers actionBuffers)
	{
		// Actions, size = 2
		Vector3 controlSignal = Vector3.zero;
		controlSignal.x = actionBuffers.ContinuousActions[0];
		controlSignal.z = actionBuffers.ContinuousActions[1];
		rBody.AddForce(controlSignal * speed);

		SetReward(-1 / MaxStep);

		if (StepCount >= MaxStep)
		{
			Debug.Log("Max Step Reached");
			SetReward(-1.0f);
			EndEpisode();
		}
		else if (this.transform.localPosition.y < 0)
		{
			SetReward(-1.0f);
			EndEpisode();
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		float distanceToTarget = Vector3.Distance(this.transform.localPosition, Target.localPosition);

		if (other.gameObject.CompareTag("Finish"))
		{
			Debug.Log("Finish reached");
			SetReward(1.0f);
			EndEpisode();
		}
        else if (other.gameObject.CompareTag("Labyrinth"))
		{
			Debug.Log("Wall collision");
			SetReward(-1.0f);
		}
	}

	public override void Heuristic(in ActionBuffers actionsOut)
	{
		var continuousActionsOut = actionsOut.ContinuousActions;
		continuousActionsOut[0] = Input.GetAxis("Horizontal");
		continuousActionsOut[1] = Input.GetAxis("Vertical");
	}
}
