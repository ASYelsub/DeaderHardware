using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScreen : MonoBehaviour
{
    public bool changeTriggered;
    public int sceneToLoad;

    private void Start()
    {
        sceneToLoad = DoorScript.staticSceneToLoad;
        SR.color = Color.black;
        if (loadStart)
        {
            StartCoroutine(initLoad());
        }
    }

    AsyncOperation asyncLoad;
    public SpriteRenderer SR;
    public bool loadStart;
    void Update()
    {
        // Press the space key to start coroutine
        if (Input.GetKeyDown(KeyCode.Space) &&!changeTriggered &&!loadStart)
        {
            changeTriggered = true;
            LOAD();
        }
        if (asyncLoad!=null)
        {
            if (asyncLoad.progress >= .9f)
            {
                SR.color = Color.Lerp(SR.color, new Color(0, 0, 0, 1.1f), Time.deltaTime * 4);
                if (SR.color.a >= 1)
                {
                    print("LOADING SCENE FROM ASYNC...");
                    asyncLoad.allowSceneActivation = true;
                }
            }
            else
            {
                SR.color = Color.Lerp(SR.color, new Color(0, 0, -.1f, 0), Time.deltaTime * 4);
            }
        }
        else
        {
            SR.color = Color.Lerp(SR.color, new Color(0, 0, -.1f, 0), Time.deltaTime * 4);
        }
    }

    IEnumerator initLoad()
    {
        yield return new WaitForSeconds(1.25f);
        LOAD();
    }

    void LOAD()
    {
        asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncLoad.allowSceneActivation = false;
    }
}
