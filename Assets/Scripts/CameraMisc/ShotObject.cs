using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotObject : MonoBehaviour {
    public void SetShot() {
        Transform camTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        transform.position = camTransform.position;
        transform.rotation = camTransform.rotation;
    }

    void OnDrawGizmos() {

        //dont talk to me about this
        //yes it was awful to write
        //yes i feel awful
        //yes there are better ways to do this

        Debug.DrawRay(transform.position, (Vector3.Normalize(transform.forward) * 3) + transform.right + transform.up);
        Debug.DrawRay(transform.position, (Vector3.Normalize(transform.forward) * 3) + transform.right - transform.up);
        Debug.DrawRay(transform.position, (Vector3.Normalize(transform.forward) * 3) - transform.right + transform.up);
        Debug.DrawRay(transform.position, (Vector3.Normalize(transform.forward) * 3) - transform.right - transform.up);

        Debug.DrawLine(transform.position + (Vector3.Normalize(transform.forward) * 3) + transform.right + transform.up, transform.position + (Vector3.Normalize(transform.forward) * 3) + transform.right - transform.up);
        Debug.DrawLine(transform.position + (Vector3.Normalize(transform.forward) * 3) + transform.right + transform.up, transform.position + (Vector3.Normalize(transform.forward) * 3) - transform.right + transform.up);
        Debug.DrawLine(transform.position + (Vector3.Normalize(transform.forward) * 3) + transform.right - transform.up, transform.position + (Vector3.Normalize(transform.forward) * 3) - transform.right - transform.up);
        Debug.DrawLine(transform.position + (Vector3.Normalize(transform.forward) * 3) - transform.right - transform.up, transform.position + (Vector3.Normalize(transform.forward) * 3) - transform.right + transform.up);

    }

}
