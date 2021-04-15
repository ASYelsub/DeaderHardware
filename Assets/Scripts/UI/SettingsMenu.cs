using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{

    [Header("General")]
    [HideInInspector] public bool settingsActive;
    [HideInInspector] public bool menuIsMoving;
    [SerializeField] Transform topPanelTransform;
    [SerializeField] Transform bottomPanelTransform;

    //All local positions.
    [Header("Panel Positions")]
    [SerializeField] private Vector3 topPanelOnPos;
    [SerializeField] private Vector3 topPanelOffPos;
    [SerializeField] private Vector3 botPanelOnPos;
    [SerializeField] private Vector3 botPanelOffPos;

    [Header("Elements")]
    [SerializeField] private GameObject[] volumeMusic;
    [SerializeField] private GameObject[] volumeSFX;
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject[] primaryCol;
    [SerializeField] private GameObject[] secondaryCol;
    [SerializeField] private GameObject[] quitButton;
    [SerializeField] private GameObject homePanel;

    [Header("Raycast Stuff")]
    [SerializeField] private Camera cam;
    public Ray buttonRay;
    Vector3 point;

    [Header("Theme")]
    private Theme currentTheme;
    [SerializeField]
    private Theme[] themes;
    private bool themeTagMoving;

    private int musicVol = 5;
    private int SFXVol = 5;
    bool homePrompt = false;
    [System.Serializable]
    private class Theme {
        public GameObject element;
        public bool selected;
        [HideInInspector]public Transform themeTransform;
        public Vector3 offPos;
        public Vector3 onPos;
        public Material primaryMat;
        public Material secondaryMat;

        //export filename.html
        //name .html file index.html
        //compress javascript and html file
        //export filename.bin
        public void SetProperties()
        {
            themeTransform = element.GetComponent<Transform>();
        }
    }

    private void Start(){
        homePanel.SetActive(false);
        topPanelTransform.localPosition = topPanelOffPos;
        bottomPanelTransform.localPosition = botPanelOffPos;

        //All of these should be read from
        //whatever save file we have
        //but for now i'm just initalizing like this.
        for (int i = 0; i < themes.Length; i++)
        {
            themes[i].SetProperties();
            if (themes[i].selected)
            {
                currentTheme = themes[i];
            }
        }
        SetTheme();
        SetMusicVolume(musicVol);
        SetSFXVolume(SFXVol);
        settingsActive = false;
        menuIsMoving = false;

      
    }


    void Update(){

        if (!ServicesLocator.GameManager.diaMan.isShowing)
        {
            if (!menuIsMoving)
            {
                if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.Escape))
                {
                    TurnMenuOnOff(settingsActive);
                }
                if (settingsActive)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        point = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                        point.z = -10;
                        ButtonRay();
                    }
                }
            }

           // ShowRay();
        }
        
    }

    public void TurnMenuOnOff(bool currentMenuState){
        if (!currentMenuState)
        {
            StartCoroutine(MoveMenuOn());
        }
        else if (currentMenuState)
        {
            StartCoroutine(MoveMenuOff());
        }
        menuIsMoving = true;
    }
    private IEnumerator MoveMenuOn(){
        float timer = 0;
        while (timer < 1)
        {
            topPanelTransform.localPosition = Vector3.Lerp(topPanelOffPos, topPanelOnPos, timer);
            bottomPanelTransform.localPosition = Vector3.Lerp(botPanelOffPos, botPanelOnPos, timer);
            timer = timer + .01f;
            yield return null;
        }
        menuIsMoving = false;
        settingsActive = true;
        yield return null;
    }
    private IEnumerator MoveMenuOff(){
        float timer = 0;
        while (timer < 1)
        {
            topPanelTransform.localPosition = Vector3.Lerp(topPanelOnPos, topPanelOffPos, timer);
            bottomPanelTransform.localPosition = Vector3.Lerp(botPanelOnPos, botPanelOffPos, timer);
            timer = timer + .01f;
            yield return null;
        }
        menuIsMoving = false;
        settingsActive = false;
        yield return null;
    }
    private void ChangeTheme(int t)
    {
        if (!themeTagMoving && themes[t].selected != true)
        {
            StartCoroutine(MoveThemeOff());
            for (int i = 0; i < themes.Length; i++)
            {
                
                if (i == t)
                {
                    themes[i].selected = true;
                    currentTheme = themes[i];
                    StartCoroutine(MoveThemeOn());
                }
                else
                {
                    themes[i].selected = false;
                }
            }
        }
        
    }
    private IEnumerator MoveThemeOff()
    {
        themeTagMoving = true;
        float timer = 0;
        while (timer < 1)
        {
            currentTheme.themeTransform.localPosition = 
                Vector3.Lerp(currentTheme.onPos, currentTheme.offPos, timer);
            timer = timer + .1f;
            yield return null;
        }
        yield return null;
    }
    private IEnumerator MoveThemeOn()
    {
        float timer = 0;
        while (timer < 1)
        {
            currentTheme.themeTransform.localPosition = 
                Vector3.Lerp(currentTheme.offPos, currentTheme.onPos, timer);
            timer = timer + .1f;
            yield return null;
        }
        themeTagMoving = false;
        SetTheme();
        yield return null;
    }
    void SetTheme()
    {
        for (int i = 0; i < primaryCol.Length; i++)
        {
            primaryCol[i].GetComponent<MeshRenderer>().material = currentTheme.primaryMat;
        }
        for (int i = 0; i < secondaryCol.Length; i++)
        {
            secondaryCol[i].GetComponent<MeshRenderer>().material = currentTheme.secondaryMat;
        }
        for (int i = 0; i < themes.Length; i++)
        {
            if (themes[i].selected)
            {
                themes[i].themeTransform.localPosition = themes[i].onPos;
            }
            else
            {
                themes[i].themeTransform.localPosition = themes[i].offPos;
            }
        }
        SetMusicVolume(musicVol);
        SetSFXVolume(SFXVol);
    }

    void ShowRay()
    {
        if (isHitting)
        {
            Debug.DrawRay(buttonRay.origin, buttonRay.direction * globalHit.distance, Color.magenta);
            //Debug.Log("Ray hit " + globalHit.collider.gameObject);
        }
    }
     
    bool isHitting = false;

    RaycastHit globalHit;
    void ButtonRay()
    {
        buttonRay = cam.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(buttonRay, out hit))
        {
            
            Debug.DrawRay(buttonRay.origin, buttonRay.direction*hit.distance, Color.magenta);
            globalHit = hit;
            ShowRay();
            isHitting = true;
            if (hit.collider.tag == "Theme")
            {ChangeTheme(hit.collider.gameObject.GetComponent<SettingsButton>().themeInt);}
            if(hit.collider.tag == "Music")
            { SetMusicVolume(hit.collider.gameObject.GetComponent<SettingsButton>().soundInt); }
            if(hit.collider.tag == "SFX")
            { SetSFXVolume(hit.collider.gameObject.GetComponent<SettingsButton>().soundInt); }
            if(hit.collider.tag == "Quit")
            { if (homePrompt == false)
                {
                    EnableHomePrompt();
                    print("Yo");
                }
                else if (homePrompt == true)
                {
                    DisableHomePrompt();
                    
                }
            }
            if (hit.collider.tag == "Y")
            { if (homePrompt == true) { Quit(); } }
            if(hit.collider.tag == "N")
            {
                if (homePrompt == true) {
                    DisableHomePrompt();
                    
                }
            }

        }
    }

    private void EnableHomePrompt()
    {
        homePrompt = true;
        homePanel.SetActive(true);
    }
    private void DisableHomePrompt()
    {
        homePrompt = false;
        homePanel.SetActive(false);
    }
    private void Quit()
    {
        Debug.Log("quit");
        SceneManager.LoadScene("MainMenu");
       
    }

    void SetMusicVolume(int f)
    {
        musicVol = f;
        for (int i = 0; i < volumeMusic.Length; i++)
        {
            if(f == i)
            {
                volumeMusic[i].GetComponent<MeshRenderer>().material = currentTheme.secondaryMat;
            }
            else
            {
                volumeMusic[i].GetComponent<MeshRenderer>().material = currentTheme.primaryMat;
            }
        }
    }
    void SetSFXVolume(int f)
    {
        SFXVol = f;
        for (int i = 0; i < volumeMusic.Length; i++)
        {
            if (f == i)
            {
                volumeSFX[i].GetComponent<MeshRenderer>().material = currentTheme.secondaryMat;
            }
            else
            {
                volumeSFX[i].GetComponent<MeshRenderer>().material = currentTheme.primaryMat;
            }
        }
    }


    public void SetSoundActive(int i)
    {

    }

    public void SetSoundInactive(int i)
    {

    }
}
