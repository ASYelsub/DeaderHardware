using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public static int currentBuildIndex;

    void Update()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeScene(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

}
