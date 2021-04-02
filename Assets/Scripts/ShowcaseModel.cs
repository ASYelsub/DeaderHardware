using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this script on an object you want to rotate and move slightly up and down.
public class ShowcaseModel : MonoBehaviour
{
    [Header("Rotation & Bounce")]
    GameObject rotateObject;
    Vector3 rotateVector;
    public float rotateSpeed;
    public float bounceSpeed;
    float timer = 0f;
    Vector3 initialPos;

    void Start()
    {
        rotateObject = this.gameObject;
        rotateVector = new Vector3(0, rotateSpeed);
        initialPos = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
    }
    private void FixedUpdate()
    {
        timer += 1 * bounceSpeed;
        rotateObject.transform.Rotate(rotateVector);
        rotateObject.transform.localPosition = new Vector3(initialPos.x, initialPos.y + Mathf.Sin(timer) * bounceSpeed, initialPos.z);
    }

   
}
