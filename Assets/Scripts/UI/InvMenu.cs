using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvMenu : MonoBehaviour
{

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

    public List<Item> itemList;


    
    //tracks whichever item is "selected",
    //corresponds with the itemID
    int activeItemInt;
    
    //amount of items visible on UI at once
    int visItem = 9;

    //variable that changes when list is messed with
    int visItem2 = 9;
    //for decreasing, i guess
    int visItem3 = 9;
    
    public float tagSpacer;
    
    //amount of items that have been picked up
    static int itemCounter = 0;


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
        public void SetPos(Vector3 pos){
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
            this.isEmpty = false;
            this.tagText.text = ServicesLocator.ItemLibrary.ItemList[ID].name;
            this.tagDesc = ServicesLocator.ItemLibrary.ItemList[ID].UIDesc;
        }

    }
    static int bookCounter = 0;
    public void SetBook(int ID)
    {

    }
   
    public void AddItem(int ID){
        //check if the amount of items is less than the amount of items in the itemLibrary
        if (itemCounter < ServicesLocator.ItemLibrary.ItemList.Count){
            //check if amount of collected items is less than spanwed tags
            if (itemCounter < visItem){
                itemTags[itemCounter].AssignItem(ID);
            }else{ //if it's more, create a new tag and assign the new item. 
                itemTags.Add(new ItemTag(tagPrefab, tagParent));
                itemTags[itemCounter].SetPos(new Vector3(2.4f, 0.001f, -4.153f));
                itemTags[itemCounter].AddPos(new Vector3(0, 0, itemCounter * tagSpacer));
                itemTags[itemCounter].visual.SetActive(true); //set this to false
                itemTags[itemCounter].AssignItem(ID);
            }
            itemCounter++;
        }
        DisplayActive();
    }

    public void Start()
    {
        itemList = new List<Item>();

        //create the tags with no items in them
        for (int i = 0; i < visItem; i++)
        {
            itemTags.Add(new ItemTag(tagPrefab, tagParent));
            itemTags[i].SetPos(new Vector3(2.4f, 0.001f, -4.153f));
            itemTags[i].AddPos(new Vector3(0, 0, i * tagSpacer));
            itemTags[i].visual.SetActive(true);
        }
        menuOn = false;
        menuIsMoving = false;
        menuObject.SetActive(menuOn);
    }

    public void DoInvMenu()
    {
        Debug.Log("this was called");
        DisplayActive();
    }

    void CycleActive(bool increase)
    {
        if (itemCounter == 0) { }//don't do anything!
        //if increasing
        else if (increase){
            /*if (itemCounter <= visItem){//if visible items isn't filled up and going down
                //if at bottom of collected items
                if (activeItemInt == itemCounter - 1){
                    activeItemInt = 0;
                }else{//if not at bottom of collected items
                    activeItemInt++;
                }
            }else{//if visible items is filled and going down
                if (activeItemInt >= visItem2 - 1){ //if visible items is filled and at bottom of visible items
                    if (activeItemInt == itemCounter - 1){//if visible items is filled and at bottom of collected items
                        for (int i = 0; i < itemTags.Count; i++){
                            itemTags[i].AddPos(new Vector3(0, 0, (visItem2 - visItem) * tagSpacer));
                            if (i <= visItem - 1)
                                itemTags[i].visual.SetActive(true);
                            else
                                itemTags[i].visual.SetActive(false);
                        }
                        visItem2 = 9;
                        activeItemInt = 0;
                    }else{ //if visible items is filled and not at the bottom of collected items
                        itemTags[visItem2].visual.SetActive(true);
                        itemTags[visItem2 - visItem].visual.SetActive(false);
                        for (int i = 0; i < itemTags.Count; i++){
                            itemTags[i].AddPos(new Vector3(0, 0, -tagSpacer));
                        }
                        visItem2++;
                        activeItemInt++;
                    }
                }else{//if not at bottom of visible items
                    activeItemInt++;
                }
            }*/
        }else if (!increase){ //if decreasing
            if (itemCounter <= visItem) {//if visible items isn't filled up
                if (activeItemInt == 0) { //if at top of collected items
                    activeItemInt = itemCounter - 1;
                } else {//if not at bottom of collected items
                    activeItemInt--;
                }
            } else {//if collected items is more than visible items
                if (activeItemInt == 0)//if at top of visible items
                {
                    if (visItem3 == 9)//if items are in original visItem configuration
                    {
                        Debug.Log("1");
                        for (int i = 0; i < itemTags.Count; i++)
                        {
                            itemTags[i].AddPos(new Vector3(0, 0, -tagSpacer));
                        }
                        activeItemInt = itemTags.Count - 1;
                        visItem3 = itemTags.Count - 1;
                    }
                    else //if not at the top of all items
                    {
                        Debug.Log("2");
                        //move everything down 1
                    }
                }
                else//if not at top of visible items
                {
                    activeItemInt--;
                }
            }
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

            if (Input.GetKeyDown(KeyCode.F))
            {
                AddItem(itemCounter);
            }

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


}
