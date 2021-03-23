using UnityEngine;

public class InteractionVolume : MonoBehaviour, IInteractable {

    // INTERACTION STUFF //

    public bool withinTrigger;
    public GameObject TextPopUp;

    //
    public bool OtherTarget;

    public GameObject triggerTarget;
    private GameObject _triggerTarget;

    public GameObject[] triggerObjects;
    private ITriggerable[] _triggerableArray;

    void Start() {
        //Set Object to be looking for
        if (!OtherTarget) _triggerTarget = GameObject.FindGameObjectWithTag("Player");
        else _triggerTarget = triggerTarget;
        triggerTarget = _triggerTarget;

        //Make Invisible
        GetComponent<MeshRenderer>().enabled = false;
        TextPopUp.GetComponent<MeshRenderer>().enabled = false;

        //Configure Triggerable Array
        _triggerableArray = new ITriggerable[triggerObjects.Length];

        int i = 0;
        foreach (GameObject n in triggerObjects) {
            if (n.GetComponent<ITriggerable>() == null) return;
            _triggerableArray[i] = n.GetComponent<ITriggerable>();
            i++;
        }

    }

    public void OnTriggerStay(Collider other) {

        if (other.gameObject != _triggerTarget) return;

        withinTrigger = true;
        TextPopUp.GetComponent<MeshRenderer>().enabled = true;

    }

    public void OnTriggerExit(Collider other) {

        if (other.gameObject != _triggerTarget) return;


        TextPopUp.GetComponent<MeshRenderer>().enabled = false;
        withinTrigger = false;

    }

    public void ExecuteInteraction() {

        if (!withinTrigger) return;

        Debug.Log("Executing Trigger Functions...");
        foreach (ITriggerable n in _triggerableArray) {
            n.ExecuteTriggerFunction();
        }
    }

    public void OnDrawGizmos() {

        if (triggerObjects.Length == 0) return;

        foreach (GameObject n in triggerObjects) {
            if (n == null) return;
            Debug.DrawLine(transform.position, n.transform.position, Color.red);
        }
    }
}
