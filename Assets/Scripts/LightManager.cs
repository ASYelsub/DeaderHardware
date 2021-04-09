using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<Light> lightsInScene;

    [System.Serializable]
    public class Light
    {
        public int lightInt;
        public GameObject lightObject;
        public bool marked = false;
        public Light()
        {
            marked = false;
        }

        public void Enable()
        {
            this.lightObject.SetActive(true);
        }
        public void Disable()
        {
            this.lightObject.SetActive(false);
        }
    }


    [System.Serializable]
    public class ShotData
    {
        public List<int> activeLightInt;
    }

    public List<ShotData> Shots;
    private ShotData activeShot;

    

    public void UpdatelightManager(int shot)
    {
        //set the active shot
        if(shot < Shots.Count) { 
            activeShot = Shots[shot];
        //go through integers in activeshot

        
        
            for (int i = 0; i < activeShot.activeLightInt.Count; i++)
            {
                print("this happened " + i + " times.");
                //go through lights in scene
                for (int j = 0; j < lightsInScene.Count; j++)
                {
                    if (lightsInScene[j].lightInt == activeShot.activeLightInt[i])
                    {
                        lightsInScene[j].marked = true;
                    }
                }
            }

            for (int i = 0; i < lightsInScene.Count; i++)
            {
                if (lightsInScene[i].marked)
                    lightsInScene[i].Enable();
                else
                    lightsInScene[i].Disable();
            }


            //reset mark for all lights
            for (int i = 0; i < lightsInScene.Count; i++)
            {
                lightsInScene[i].marked = false;
            }
        }
        else
        {
            print("No thing yet.");
        }
        
    }
}
