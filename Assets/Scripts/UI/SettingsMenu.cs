using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [SerializeField] private GameObject[] volume;
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject[] primaryCol;
    [SerializeField] private GameObject[] secondaryCol;
    [SerializeField] private GameObject[] quitButton;

    [Header("Volume")]
    private int vol;

    [Header("Raycast Stuff")]
    [SerializeField] private Camera cam;
    public Ray buttonRay;
    Vector3 point;

    [Header("Theme")]
    private Theme currentTheme;
    [SerializeField]
    private Theme[] themes;
    private bool themeTagMoving;

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
        vol = 5;
        settingsActive = false;
        menuIsMoving = false;

      
    }


    void Update(){
        if (!menuIsMoving){
            if (Input.GetKeyDown(KeyCode.P )|| Input.GetKey(KeyCode.Alpha1)){
                TurnMenuOnOff(settingsActive);
            }
            if (settingsActive){
                if (Input.GetMouseButtonDown(0)){
                    point = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    point.z = -10;
                    ButtonRay();
                }
            }
        }

        ShowRay();
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
           
            if (hit.collider.tag == "Quit")
            {
                Quit();
            }
            if (hit.collider.tag == "T1")
            {ChangeTheme(0);}
            if (hit.collider.tag == "T2")
            {ChangeTheme(1);}
            if (hit.collider.tag == "T3")
            {ChangeTheme(2);}
            if (hit.collider.tag == "T4")
            {ChangeTheme(3);}
            if(hit.collider.tag == "V6")
            {SetMusicVolume(4);}
            if(hit.collider.tag == "V7")
            {SetMusicVolume(5);}
            if(hit.collider.tag == "V8")
            {SetMusicVolume(6);}
            if(hit.collider.tag == "V9")
            {SetMusicVolume(7);}
            if(hit.collider.tag == "V10")
            {SetMusicVolume(8);}
            if(hit.collider.tag == "V11")
            {SetMusicVolume(9);}
            if(hit.collider.tag == "V10")
            {SetMusicVolume(10);}
            if(hit.collider.tag == "V11")
            {SetMusicVolume(11);}
            if (hit.collider.tag == "V12")
            {SetSFXVolume(12);}
            if (hit.collider.tag == "V12")
            {SetMusicVolume(13);}
            if (hit.collider.tag == "V13")
            {SetMusicVolume(9);}
        }
    }
    private void Quit()
    {
        Debug.Log("quit");
        //Application.Quit();
       
    }

    void SetMusicVolume(int i)
    {

    }
    void SetSFXVolume(int i)
    {

    }

}
