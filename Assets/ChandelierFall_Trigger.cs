using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChandelierFall_Trigger : MonoBehaviour, ITriggerable
{
    public bool open;

    public Transform chandelier;
    public GameObject chandelierData;
    public AudioClip chandelierCrash;

    

    void FixedUpdate()
    {
       
        if (open)
        {
            Debug.Log("Yes");
            Vector3 c = chandelier.localPosition;
            chandelier.localPosition = Vector3.Lerp(chandelier.localPosition, new Vector3(c.x, -2.85f, c.z), Time.deltaTime * 5);
        }
    }
    public void ExecuteLeaveTriggerFunction()
    {
        //   throw new System.NotImplementedException();
    }

    public void ExecuteTriggerFunction()
    {
        open = true;
        chandelierData.SetActive(false);
        Debug.Log("Executed");
        StartCoroutine(EndGameCountDown());
       
    }

    private IEnumerator EndGameCountDown()
    {
        float timer = 0;
        while(timer < 1)
        {
            
            timer = timer + .01f;
            yield return null;
        }
        //PlayOneShot ChandelierCrash
        //Scenemanager.loadScene(End)
        yield return null;
    }
}
