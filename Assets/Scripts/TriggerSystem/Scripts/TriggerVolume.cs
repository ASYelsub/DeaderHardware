using UnityEngine;

public class TriggerVolume : MonoBehaviour, IInteractable
{
    public bool OtherTarget;
    public bool ExecuteOnAwake;

    public GameObject triggerTarget;
    private GameObject _triggerTarget;

    public GameObject[] triggerObjects;
    private ITriggerable[] _triggerableArray;

    void Start()
    {
        //Set Object to be looking for
        if (!OtherTarget) _triggerTarget = GameObject.FindGameObjectWithTag("Player");
        else _triggerTarget = triggerTarget;
        triggerTarget = _triggerTarget;

        //Make Invisible
        GetComponent<MeshRenderer>().enabled = false;

        //Configure Triggerable Array
        _triggerableArray = new ITriggerable[triggerObjects.Length];

        int i = 0; 
        foreach (GameObject n in triggerObjects) {
            if (n.GetComponent<ITriggerable>() == null) return;
            _triggerableArray[i] = n.GetComponent<ITriggerable>();
            i++;
        }

        //Execute On Awake?
        if (ExecuteOnAwake) OnTriggerEnter(this.GetComponent<Collider>());
    }

    public void OnTriggerEnter(Collider other) {

        if (!ExecuteOnAwake && other.gameObject != _triggerTarget) return;

//        Debug.Log("Executing Trigger Functions...");

        foreach (ITriggerable n in _triggerableArray) {
            n.ExecuteTriggerFunction();
        }
    }

    public void OnDrawGizmos() {
        foreach (GameObject n in triggerObjects) {
            if (n == null) return;
            Debug.DrawLine(transform.position, n.transform.position, Color.red);
 
        }
    }

    public void ExecuteInteraction()
    {
        foreach (IInteractable g in GetComponentsInChildren<IInteractable>())
        {
            if (g != this.gameObject.GetComponent<IInteractable>())
            {
                g.ExecuteInteraction();
            }
        }
    }
}
