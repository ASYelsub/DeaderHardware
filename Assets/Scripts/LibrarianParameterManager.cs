using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class LibrarianParameterManager : MonoBehaviour
{
    public GameObject[] librarians;

    private Transform player;
    private float dis;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < librarians.Length; i++)
        {
            dis = Mathf.Min(dis, Vector3.Distance(player.position, librarians[i].transform.position));
        }
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("LibRange", dis);
        dis = 1000;
    }
}
