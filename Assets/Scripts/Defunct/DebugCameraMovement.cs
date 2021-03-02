using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugCameraMovement : MonoBehaviour
{
    public Vector3[] positions;
    public Vector3[] rotations;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float minDist;
    public int activePos;

    // Update is called once per frame
    void Update()
    {
        minDist = Mathf.Infinity;
        for (int i = 0; i < positions.Length; i++)
        {
            if(Vector3.Distance(positions[i],player.position)<minDist)
            {
                minDist = Vector3.Distance(positions[i], player.position);
                activePos = i;
            }
        }

        transform.position = positions[activePos];
        transform.rotation = Quaternion.Euler(rotations[activePos]);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Vector3 vector3 in positions)
        {
            Gizmos.DrawWireSphere(vector3, .5f);
        }
    }
}
