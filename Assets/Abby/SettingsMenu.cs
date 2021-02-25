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

    [Header("Materials")]
    [SerializeField] private Material[] t1;
    [SerializeField] private Material[] t2;
    [SerializeField] private Material[] t3;
    [SerializeField] private Material[] t4;

    [Header("Elements")]
    [SerializeField] private GameObject[] volume;
    [SerializeField] private GameObject[] theme;
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject[] primaryCol;
    [SerializeField] private GameObject[] secondaryCol;

    [Header("Volume")]
    private int vol;

    [Header("Theme")]
    private int themeVal;
    private Transform pickedTheme;
    private Transform oldPickedTheme;
    private Transform[] unPickedTheme = new Transform[3];
    private bool themeTagMoving;
    private Material currentPrimaryMat;
    private Material currentSecondaryMat;


    [Header("Raycast Stuff")]
    Vector2 mousePos;
    [SerializeField] private Camera cam;
    bool shootRay;
    public Ray buttonRay;
    Vector3 point;
    Vector3 worldPos;

    private void Start(){

        //All of these should be read from
        //whatever save file we have
        //but for now i'm just initalizing like this.
        themeVal = 0;
        pickedTheme = theme[themeVal].transform;
        vol = 5;
        settingsActive = false;
        menuIsMoving = false;
        themeTagMoving = false;

        topPanelTransform.localPosition = topPanelOffPos;
        bottomPanelTransform.localPosition = botPanelOffPos;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape) && !menuIsMoving){
            TurnMenuOnOff(settingsActive);
        }
        if (settingsActive)
        {
            MouseInputs();
            if (shootRay)
            {
                ButtonRay();
            }
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
    }

    private IEnumerator MoveMenuOn(){
        float timer = 0;
        while (timer < 1)
        {
            topPanelTransform.localPosition = Vector3.Lerp(topPanelOffPos, topPanelOnPos, timer);
           // bottomPanelTransform.localPosition = Vector3.Lerp(botPanelOffPos, botPanelOnPos, timer);
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
           // bottomPanelTransform.localPosition = Vector3.Lerp(botPanelOnPos, botPanelOffPos, timer);
            timer = timer + .01f;
            yield return null;
        }
        menuIsMoving = false;
        settingsActive = false;
        yield return null;
    }
    private void SetTheme(int themeVal)
    {
        Debug.Log("This happens");
        oldPickedTheme = pickedTheme.transform;
        float onY = pickedTheme.transform.localPosition.y;
        float offY = unPickedTheme[0].transform.localPosition.y;
        pickedTheme = theme[themeVal].transform;
        for (int i = 0; i < unPickedTheme.Length; i++)
        {
            if (i != themeVal)
            {
                if (unPickedTheme[0] == null)
                    unPickedTheme[0] = theme[i].transform;
                else if (unPickedTheme[0] != null &&
                        unPickedTheme[1] == null)
                    unPickedTheme[1] = theme[i].transform;
                else if (unPickedTheme[0] != null &&
                       unPickedTheme[1] != null &&
                       unPickedTheme[2] == null)
                    unPickedTheme[2] = theme[i].transform;
            }
        }
        Vector3 newPickedOn = new Vector3(pickedTheme.localPosition.x, oldPickedTheme.localPosition.y, pickedTheme.localPosition.z);
        Vector3 newPickedOff = pickedTheme.transform.localPosition;
        Vector3 oldPickedOn = new Vector3(oldPickedTheme.localPosition.x, pickedTheme.localPosition.y, oldPickedTheme.localPosition.z);
        Vector3 oldPickedOff = oldPickedTheme.transform.localPosition;

        themeTagMoving = true;
    }
    private IEnumerator ThemeLabel(int themeVal, 
        Vector3 newPickedOn, Vector3 newPickedOff, 
        Vector3 oldPickedOn, Vector3 oldPickedOff)
    {
        float timer = 0;
        while (timer < 1)
        {
            pickedTheme.localPosition = Vector3.Lerp(newPickedOff, newPickedOn, timer);
            oldPickedTheme.localPosition = Vector3.Lerp(oldPickedOff, oldPickedOn, timer);
            timer = timer + .01f;
            yield return null;
        }
        themeTagMoving = false;
        yield return null;
    }

    void MouseInputs()
    {
        mousePos = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        point = mousePos;
        point.z = cam.nearClipPlane;
        worldPos = cam.ScreenToWorldPoint(point);

        if (Input.GetMouseButtonDown(0))
        {
            if (!menuIsMoving)
            {
                shootRay = true;
            }
        }
    }

    void ButtonRay()
    {
        Debug.Log(worldPos.x + " " + worldPos.y);
        buttonRay = new Ray(new Vector3(worldPos.x, worldPos.y, cam.transform.position.z), Vector3.forward);
        RaycastHit hit;
        Debug.DrawRay(buttonRay.origin, buttonRay.direction, Color.magenta);
        if (Physics.Raycast(buttonRay, out hit, 100f))
        {
            Debug.DrawRay(buttonRay.origin, buttonRay.direction, Color.magenta);
            Debug.Log("Ray hit " + hit.collider.gameObject);
            if (hit.collider.tag == "T1")
            {
                Debug.Log("yeet");
                SetTheme(0);
            }
            if (hit.collider.tag == "T2")
            {
                SetTheme(1);
            }
            if (hit.collider.tag == "T3")
            {
                SetTheme(2);
            }
            if (hit.collider.tag == "T4")
            {
                SetTheme(3);
            }
        }
        shootRay = false;
    }

}
