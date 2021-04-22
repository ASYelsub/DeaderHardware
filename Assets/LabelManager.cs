using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> labels = new List<GameObject>();


    public void UpdateLabelManager(int shot)
    {
        if (shot == 10)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels[i].SetActive(true);
            }
        }
    }
}
