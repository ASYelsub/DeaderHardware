using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiCtrl : MonoBehaviour
{
    public bool patrol = false;

    public void TogglePatrolling()
	{
		patrol = !patrol;
        GetComponent<Pathfinding.Patrol>().enabled = patrol;
        GetComponent<Pathfinding.AIDestinationSetter>().enabled = !patrol;

    }
}
