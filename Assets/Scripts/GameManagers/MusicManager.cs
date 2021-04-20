using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource AS;
    public AudioClip[] tracks;

    public void Initialize()
    {
        AS = FindObjectOfType<AudioSource>();
        initializeTracks();
        //DeleteOtherManager();
    }

    void initializeTracks()
    {
//        tracks = (AudioClip[]) Resources.LoadAll("Music",typeof(AudioClip)); //loads all tracks from folder Assets\Resources\Music
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



    public void changeTrack(int trackID)
    {
        if (tracks == null) return;

        AS.Stop();
        if (!tracks[trackID]) { print("Track doesn't exist!"); return; }
        AS.clip = tracks[trackID];
        AS.Play();
    }

}
