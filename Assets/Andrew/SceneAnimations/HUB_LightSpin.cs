using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUB_LightSpin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        yrot = transform.rotation.eulerAngles.y;
    }
    float yrot;
    // Update is called once per frame
    void Update()
    {
        yrot += Time.deltaTime * 30;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yrot, transform.rotation.eulerAngles.z);
    }
}
