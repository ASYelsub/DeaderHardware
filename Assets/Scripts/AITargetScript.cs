using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetScript : MonoBehaviour
{
	public GameObject ai;
	public GameObject player;
	private Vector3 previousDestination = default;

    public void Stop() // stop the ai (then store previous destination)
	{
		previousDestination = transform.position;
		transform.position = ai.transform.position;
	}

	public void Resume() // resume moving to stored destination
	{
		if (previousDestination != default)
		{
			transform.position = previousDestination;
		}
	}

	public void ChasePlayer() // chase down player
	{
		if (player == null)
		{
			Debug.LogError("no player found");
			return;
		}
		else
		{
			transform.position = player.transform.position;
		}
	}

	public void MoveTo(Vector3 pos) // move to a specific location (and clear stored destination)
	{
		transform.position = pos;
		previousDestination = default;
	}
}
