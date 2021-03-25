using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionQuery : MonoBehaviour
{
    public int requiredItemId;

    public GameObject[] triggerObjectsOnSuccess;
    private ITriggerable[] _triggerableArrayOnSuccess;

    public GameObject[] triggerObjectsOnFailure;
    private ITriggerable[] _triggerableArrayOnFailure;

    public void Start() {

        //Configure Arrays

        _triggerableArrayOnSuccess = new ITriggerable[triggerObjectsOnSuccess.Length];

        int i = 0;
        foreach (GameObject n in triggerObjectsOnSuccess) {
            if (n.GetComponent<ITriggerable>() == null) return;
            _triggerableArrayOnSuccess[i] = n.GetComponent<ITriggerable>();
            i++;
        }

        _triggerableArrayOnFailure = new ITriggerable[triggerObjectsOnFailure.Length];

        i = 0;
        foreach (GameObject n in triggerObjectsOnFailure) {
            if (n.GetComponent<ITriggerable>() == null) return;
            _triggerableArrayOnFailure[i] = n.GetComponent<ITriggerable>();
            i++;
        }
    }

    public void ExecuteInteractionQuery(int id) {
        if (id == requiredItemId) {

            Debug.Log("Success: " + id);
            ServicesLocator.GameManager.invM.RemoveItem(id);
            if (_triggerableArrayOnSuccess.Length == 0) return;

            foreach (ITriggerable n in _triggerableArrayOnSuccess) {
                n.ExecuteTriggerFunction();
            }

        } else {

            Debug.Log("Failure: " + id);

            if (_triggerableArrayOnFailure.Length == 0) return;

            foreach (ITriggerable n in _triggerableArrayOnFailure) {
                n.ExecuteTriggerFunction();
            }

        }
    }
}
