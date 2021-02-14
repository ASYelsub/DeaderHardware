using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    public bool OtherTarget;

    public GameObject triggerTarget;
    private GameObject _triggerTarget;

    public GameObject[] triggerObjects;

    void Start()
    {
        //Set Object to be looking for
        if (!OtherTarget) _triggerTarget = GameObject.FindGameObjectWithTag("Player");
        else _triggerTarget = triggerTarget;
        triggerTarget = _triggerTarget;


    }

    public void OnTriggerEnter(Collider other) {

        if (other.gameObject != _triggerTarget) return;

        Debug.Log("Executing Trigger Functions");

        foreach (GameObject n in triggerObjects) {

            if (n.GetComponent<ITriggerable>() == null) return;

            n.GetComponent<ITriggerable>().ExecuteTriggerFunction();

        }
    }
}
