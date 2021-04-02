using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [System.Serializable]
    public class LightHolder
    {
        public GameObject[] lights;
    }

    public List<LightHolder> lightHolders;

    public void UpdatelightManager(int shot)
    {
        for (int i = 0; i < lightHolders.Count; i++)
        {
            if (i == shot)
            {
                for (int j = 0; j < lightHolders[i].lights.Length; j++)
                {
                    lightHolders[i].lights[j].SetActive(true);
                }

            }
            else
            {
                for (int j = 0; j < lightHolders[i].lights.Length; j++)
                {
                    lightHolders[i].lights[j].SetActive(false);
                }

            }
        }
        Debug.Log("setting lights for " + shot);
    }
}
