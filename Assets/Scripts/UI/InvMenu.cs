using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvMenu : MonoBehaviour
{
    [Header("Raycast Stuff")]
    private Camera cam;
    public Ray buttonRay;
    Vector3 point;

    [SerializeField]
    Material activeMat;
    [SerializeField]
    Material inactiveMat;

    private bool menuOn;
    private bool menuIsMoving;

    [SerializeField]
    private GameObject menuObject;
    [SerializeField]
    private Transform menuTransform;

    [SerializeField]
    private List<Item> collectedItems = new List<Item>();
    private List<ItemTag> itemTags = new List<ItemTag>();
    [SerializeField]
    private GameObject tagParent;

    [SerializeField]
    private GameObject tagPrefab;

    [Header("Right Panel")]
    [SerializeField]
    private GameObject rightDesc;
    private GameObject rightModel;

    //Item script: goes on every object
    //has the properties:
    //Name
    //ID
    //UI Description
    //UI Model
    //isBook
    //Hover Writing
    //In world model object
    //Item data script

    [HideInInspector]
    public ItemLibrary il = ServicesLocator.ItemLibrary;
        
    public class ItemTag
    {
        [HideInInspector] public Vector3 tagPos;
        [HideInInspector] public GameObject visual;
        [HideInInspector] public TextMeshPro tagText;
        [HideInInspector] public GameObject model;
        [HideInInspector] public bool isEmpty;
        [HideInInspector] public string tagDesc;
        [HideInInspector]
        public Item tagItem;


        //For when created without an item, empty, to take up space
        public ItemTag(GameObject tagPrefab, GameObject tagParent)
        {
            tagPos = new Vector3(0, 0, 0);
            visual = Instantiate(tagPrefab, tagParent.transform, false);
            tagText = visual.GetComponentInChildren<TextMeshPro>();
            tagText.text = "";
            visual.SetActive(false);
            isEmpty = true;
        }
        public void SetItem(string name)
        {
            if (isEmpty)
            {
                tagText.text = name;
                isEmpty = false;
            }
        }
        public void SetPos(Vector3 pos)
        {
            this.tagPos = pos;
            this.visual.GetComponent<Transform>().localPosition = tagPos;
        }
        public void AddPos(Vector3 pos)
        {
            this.tagPos += pos;
            this.visual.GetComponent<Transform>().localPosition = tagPos;
        }


        public void AssignItem(int ID)
        {
          // this.tagText.text = "hello!";
         // this.tagDesc = "description";
            this.isEmpty = false;
            this.tagText.text = ServicesLocator.ItemLibrary.ItemList[ID].name;
            this.tagDesc = ServicesLocator.ItemLibrary.ItemList[ID].UIDesc;
        }

    }
    public List<Item> itemList;
    int activemax;
    int activeItemInt;
    int visItem = 9;
    public float tagSpacer;
    int itemCounter = 0;

    public void AddItem(int ID)
    { 
        itemTags[itemCounter].AssignItem(ID);
        itemCounter++;
    }

    public void Start()
    {
        itemList = new List<Item>();
        for (int i = 0; i < 5; i++)
        {
            itemTags.Add(new ItemTag(tagPrefab, tagParent));
            itemTags[i].SetPos(new Vector3(2.4f, 0.001f, -4.153f));
            itemTags[i].AddPos(new Vector3(0, 0, i * tagSpacer));
            itemTags[i].visual.SetActive(true);
            // itemList.Add(ServicesLocator.ItemLibrary.ItemList[i]);
        }
        //activemax will become like, the amount of items in the ref
        activemax = 5;
        menuOn = false;
        menuIsMoving = false;
        menuObject.SetActive(menuOn);
        
    }

    public void DoInvMenu()
    {
        Debug.Log("this was called");
        //for testing without the trigger volume
        //AddItem(0);
        //AddItem(1);
        //AddItem(1);
        DisplayActive();
    }

    void CycleActive(bool increase)
    {
        if (increase){
            if (activeItemInt == activemax-1)
                activeItemInt = 0;
            else
                activeItemInt = activeItemInt + 1;
        }
        else{
            if (activeItemInt == 0)
                activeItemInt = activemax-1;
            else
                activeItemInt = activeItemInt - 1;

        }
        DisplayActive();
    }
    void DisplayActive()
    {
        rightDesc.GetComponent<TextMeshPro>().text=itemTags[activeItemInt].tagDesc;
        for (int i = 0; i < itemTags.Count; i++)
        {
            if (i == activeItemInt)
                itemTags[i].visual.GetComponent<MeshRenderer>().material = activeMat;
            else
                itemTags[i].visual.GetComponent<MeshRenderer>().material = inactiveMat;

        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
        if (menuOn)
        {
           /* if (Input.GetMouseButtonDown(0))
            {
                point = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                point.z = -10;
                ButtonRay();
            }*/
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                CycleActive(true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                CycleActive(false);
            }
        }
    }



    private void ToggleMenu()
    {
        menuOn = !menuOn;
        menuObject.SetActive(menuOn);
    }

    void ButtonRay()
    {
        buttonRay = cam.ScreenPointToRay(point);
        RaycastHit hit;
        if (Physics.Raycast(buttonRay, out hit))
        {
            //Debug.DrawRay(buttonRay.origin, buttonRay.direction*hit.distance, Color.magenta);
            //Debug.Log("Ray hit " + hit.collider.gameObject);

        }
    }
}
