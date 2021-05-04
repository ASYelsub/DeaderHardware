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
    [SerializeField] private Vector3 upPos;
    [SerializeField] private Vector3 downPos;


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
        
        //Vector3 c = chandelier.localPosition;
        float timer = 0;
        while(timer < 1)
        {
            chandelier.localPosition = Vector3.Lerp(upPos,downPos,timer);
            timer = timer + .01f;
            yield return null;
        }
        FMODUnity.RuntimeManager.PlayOneShot("Event:/LibraryChandelierCrash");
        //PlayOneShot ChandelierCrash
        while (timer < 1.5 && timer >= 1)
        {
            chandelier.localPosition = Vector3.Lerp(upPos,downPos,timer);
            timer = timer + .01f;
            yield return null;
        }
        SceneManager.LoadScene("CreditScene");
        yield return null;
    }
}
