using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Awake()
    {
        MoveToManagerObj();
    }

    void MoveToManagerObj()
    {
        if (!GameObject.Find("Managers"))
        {
            GameObject g = new GameObject("Managers");
            DontDestroyOnLoad(g);
        }
        DontDestroyOnLoad(this.gameObject);
        transform.parent = GameObject.Find("Managers").transform;
    }

    public AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();
        DeleteOtherManager();
    }

    void DeleteOtherManager()
    {
        foreach (MusicManager m in GameObject.Find("Managers").GetComponentsInChildren<MusicManager>())
        {
            if (m != this)
            {
                print("More than one 'MusicManager,' deleting...");
                Destroy(m.gameObject);
            }
        }
    }

    public AudioClip[] tracks;

    public void changeTrack(int trackID)
    {
        if (!tracks[trackID]) { print("Track doesn't exist!"); return; }
        AS.clip = tracks[trackID];
        AS.Play();
    }

}
