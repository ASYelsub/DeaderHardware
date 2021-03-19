using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


//make it so:
//last part of removing code
//scroll bar
//display model???
//tags dont appear if you add more items when on page after initial items
public class InvMenu : MonoBehaviour
{
    bool isStep = false;
    [SerializeField]
    Material activeMat;
    [SerializeField]
    Material inactiveMat;

    [HideInInspector]
    public bool menuOn;

    [SerializeField]
    private GameObject menuObject;

    [SerializeField]
    private List<Item> collectedItems = new List<Item>(); //will be used for removing items from menu
    private List<ItemTag> itemTags = new List<ItemTag>();
    [SerializeField]
    private GameObject tagParent;

    [SerializeField]
    private GameObject tagPrefab;
    [SerializeField]
    private GameObject scroller;
    [SerializeField]
    private GameObject scrollPointPrefab;
    [SerializeField]
    private GameObject scrollPointParent;
    [Header("Right Panel")]
    [SerializeField]
    private GameObject rightDesc;
    private GameObject rightModel;

    static int bookCounter = 0;


    //tracks whichever item is "selected",
    //corresponds with the itemID
    int activeItemInt;
    
    //amount of items visible on UI at once
    int visItem = 9;

    //variable that changes when list is messed with
    int visItem2 = 9;
    //for decreasing, i guess
    int topTrack = 0;
    
    [Header("Spacers")]
    public float tagSpacer;
    public float scrollSpacer;
    public int scrollCount;
    private int scrollSpot;
    
    //amount of items that have been picked up
    static int itemCounter = 0;

    private List<ScrollPoint> scrollPoints;
    public class ScrollPoint{
        [HideInInspector] public Vector3 pos;
        [HideInInspector] public GameObject visual;
        public ScrollPoint(GameObject parent, GameObject prefab){
            pos = prefab.GetComponent<Transform>().localPosition;
            visual = Instantiate(prefab, parent.transform, false);
        }
        public void AddPos(Vector3 pos){
            this.pos += pos;
            this.visual.GetComponent<Transform>().localPosition = this.pos;
        }
    }

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
        [HideInInspector]
        public int ID;


        //For when created without an item, empty, to take up space
        public ItemTag(GameObject tagPrefab, GameObject tagParent)
        {
            tagPos = new Vector3(0, 0, 0);
            visual = Instantiate(tagPrefab, tagParent.transform, false);
            tagText = visual.GetComponentInChildren<TextMeshPro>();
            tagText.text = "";
            visual.SetActive(false);
            isEmpty = true;
            ID = -1; //correlates w duplicates
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
        public void AddPos(Vector3 pos){
            this.tagPos += pos;
            this.visual.GetComponent<Transform>().localPosition = tagPos;
        }


        public void AssignItem(int ID)
        {
            this.isEmpty = false;
            this.tagText.text = ServicesLocator.ItemLibrary.ItemList[ID].name;
            this.tagDesc = ServicesLocator.ItemLibrary.ItemList[ID].UIDesc;
            this.ID = ID;
        }
        public void ClearTag()
        {
            if(this.isEmpty == false)
            {
                this.tagText.text = "";
                this.tagDesc = "";
                this.isEmpty = true;
            }
        }
        public void RemoveTag() {
            visual.SetActive(false);
        }

    }

    public class Book
    {

    }

    public void Start(){
        scrollPoints = new List<ScrollPoint>();
        for (int i = 0; i < scrollCount; i++)
        {
            scrollPoints.Add(new ScrollPoint(scrollPointParent,scrollPointPrefab));
            scrollPoints[i].AddPos(new Vector3(0, 0, i * scrollSpacer));
        }
        
        //create the tags with no items in them
        for (int i = 0; i < visItem; i++)
        {
            itemTags.Add(new ItemTag(tagPrefab, tagParent));
            itemTags[i].SetPos(new Vector3(2.4f, 0.001f, -4.153f));
            itemTags[i].AddPos(new Vector3(0, 0, i * tagSpacer));
            itemTags[i].visual.SetActive(true);
        }
        menuOn = false;
        menuObject.SetActive(menuOn);
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

            //This removes an item from the inventory.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //This function needs to be changed to a currently nonexistant "CheckItem(activeItemInt)" function.
                //                RemoveItem(activeItemInt);

                CheckItem(activeItemInt);

                //bool corresponds = CheckItem(activeItemint);

                //if(corresponds == true){
                //this.ToggleMenu();
                // int l = 0;
                //for(i=0; i<activeItemInt; i++){
                //}
                //dialoguemanager.splitfile()}
                //RemoveItem(activeItemInt);
            }
        }
    }

    public void CheckItem(int activeItemId) {

        int id = itemTags[activeItemInt].ID;

        ServicesLocator.PlayerInteractor.queryItemInteraction(id);
        Debug.Log("Parsing: " + id);
    }

    //?
    public void DoInvMenu()
    {
        Debug.Log("this was called");
        DisplayActive();
    }

    private int AddTest(int ID)
    {
        if (itemTags != null)
        {
            for (int i = 0; i < itemTags.Count; i++)
            {
                if (itemTags[i].ID == ID)
                {
                    ID++;
                }
            }
        }
        return ID;
    }
    private bool AddGame(int ID)
    {
        bool isCopy = false;
        if (itemTags != null){
            for (int i = 0; i < itemTags.Count; i++){
                if(itemTags[i].ID == ID){
                    isCopy = true;
                }
            }
        }
        return isCopy;
    }
    //Object manipulation related
    public void AddItem(int ID)
    {
        if (!isStep)
        {
            isStep = true;
            bool isCopy = false;

            //for test
            //ID = AddTest(ID);
            //for actual game
            isCopy = (AddGame(ID));
            if (!isCopy)
            {
                //check if the amount of items is less than the amount of items in the itemLibrary
                if (itemCounter < ServicesLocator.ItemLibrary.ItemList.Count)
                {
                    //check if amount of collected items is less than spanwed tags
                    if (itemCounter < visItem)
                    {
                        itemTags[itemCounter].AssignItem(ID);
                        Debug.Log(6);
                    }
                    else
                    { //if it's more, create a new tag and assign the new item. 
                        itemTags.Add(new ItemTag(tagPrefab, tagParent));
                        itemTags[itemCounter].SetPos(new Vector3(2.4f, 0.001f, -4.153f));
                        if (topTrack != 0) //if we've scrolled down
                        { Debug.Log(7); itemTags[itemCounter].AddPos(new Vector3(0, 0, (itemCounter - topTrack) * tagSpacer)); }

                        else { Debug.Log(8); itemTags[itemCounter].AddPos(new Vector3(0, 0, itemCounter * tagSpacer)); }

                        itemTags[itemCounter].visual.SetActive(false);
                        itemTags[itemCounter].AssignItem(ID);


                    }
                    itemCounter++;
                }
            }

            DisplayActive();
            isStep = false;
        }
        
    }

    public int RemoveItem(int index)
    {
        if (!isStep)
        {
            isStep = true;
            int toReturn = itemTags[index].ID;
            if (itemCounter == 0) //paris do you want any item at -1? i'm just using this for the null value.
                return -1;
            else if (topTrack != 0)
            {
                if (topTrack + 9 < itemCounter)
                {
                    Debug.Log(3);
                    itemTags[topTrack + visItem].visual.SetActive(true);
                    itemTags[index].RemoveTag();
                    itemTags.RemoveAt(index);
                    for (int i = 0; i < itemTags.Count; i++)
                    {
                        if (i > index - 1)
                            itemTags[i].AddPos(new Vector3(0, 0, -tagSpacer));
                    }
                    visItem2--;
                    itemCounter--;
                    topTrack--;
                    if (activeItemInt == itemCounter)
                        activeItemInt--;
                    DisplayActive();
                }
                else
                {
                    Debug.Log(4);

                    //move all the tags down i guess?



                    for (int i = 0; i < itemTags.Count; i++)
                    {
                        if (i < index)
                            itemTags[i].AddPos(new Vector3(0, 0, tagSpacer));
                    }
                    itemTags[topTrack - 1].visual.SetActive(true);
                    itemTags[index].RemoveTag();
                    itemTags.RemoveAt(index);
                    visItem2--;
                    itemCounter--;
                    topTrack--;
                    if (activeItemInt == itemCounter)
                        activeItemInt--;
                    DisplayActive();
                }
            }
            else if (itemCounter > 9)
            {
                Debug.Log(1);
                itemTags[topTrack + visItem].visual.SetActive(true);
                itemTags[index].RemoveTag();
                itemTags.RemoveAt(index);
                for (int i = 0; i < itemTags.Count; i++)
                {
                    if (i > index - 1)
                    {
                        itemTags[i].AddPos(new Vector3(0, 0, -tagSpacer));
                    }
                }
                visItem2--;
                itemCounter--;
                if (activeItemInt == itemCounter)
                    activeItemInt--;
                DisplayActive();
            }
            else
            {//if we are both at less than 9 items and 
                Debug.Log(2);
                itemTags[index].ClearTag();
                if (topTrack + 8 < itemTags.Count)
                {
                    for (int i = 0; i < itemTags.Count; i++)
                    {
                        if (i > index)
                        {
                            itemTags[i].AddPos(new Vector3(0, 0, -tagSpacer));
                        }
                    }
                    itemTags.RemoveAt(index);
                    itemTags.Add(new ItemTag(tagPrefab, tagParent));
                    itemTags[itemTags.Count - 1].SetPos(new Vector3(2.4f, 0.001f, -4.153f));
                    itemTags[itemTags.Count - 1].AddPos(new Vector3(0, 0, tagSpacer * itemTags.Count - 1));
                    itemTags[itemTags.Count - 1].visual.SetActive(true);

                }
                itemCounter--;
                if (activeItemInt == itemCounter)
                    activeItemInt--;

                if (itemCounter == 0)
                {
                    rightDesc.GetComponent<TextMeshPro>().text = "";
                }
                DisplayActive();
            }
            isStep = false;
            return toReturn;
        }
        return -1;
    }
    
    public void SetBook(int ID)
    {

    }

    //Display related
    void CycleActive(bool increase)
    {
        if (!isStep)
        {
            isStep = false;
            if (itemCounter == 0) { }//don't do anything!
            else if (increase)
            {//if increasing
                if (itemCounter <= visItem)
                {//if visible items isn't filled up and going down
                 //if at bottom of collected items
                    if (activeItemInt == itemCounter - 1)
                    {
                        activeItemInt = 0;
                    }
                    else
                    {//if not at bottom of collected items
                        activeItemInt++;
                    }
                }
                else
                {//if visible items is filled and going down
                    if (activeItemInt >= visItem2 - 1)
                    { //if visible items is filled and at bottom of visible items
                        if (activeItemInt == itemCounter - 1)
                        {//if visible items is filled and at bottom of collected items
                            for (int i = 0; i < itemTags.Count; i++)
                            {
                                itemTags[i].AddPos(new Vector3(0, 0, (visItem2 - visItem) * tagSpacer));
                                if (i <= visItem - 1)
                                    itemTags[i].visual.SetActive(true);
                                else
                                    itemTags[i].visual.SetActive(false);
                            }
                            visItem2 = 9;
                            activeItemInt = 0;
                            topTrack = 0;
                        }
                        else
                        { //if visible items is filled and not at the bottom of collected items
                            itemTags[visItem2].visual.SetActive(true);
                            itemTags[visItem2 - visItem].visual.SetActive(false);
                            for (int i = 0; i < itemTags.Count; i++)
                            {
                                itemTags[i].AddPos(new Vector3(0, 0, -tagSpacer));
                            }
                            visItem2++;
                            activeItemInt++;
                            topTrack++;
                        }
                    }
                    else
                    {//if not at bottom of visible items
                        activeItemInt++;
                    }
                }
            }
            else if (!increase)
            { //if decreasing
                if (itemCounter <= visItem)
                {//if visible items isn't filled up
                    if (activeItemInt == 0)
                    { //if at top of collected items
                        activeItemInt = itemCounter - 1;
                    }
                    else
                    {//if not at bottom of collected items
                        activeItemInt--;
                    }
                }
                else
                {//if collected items is more than visible items
                 //vis
                    if (activeItemInt != topTrack)
                    {//if we're not at the top of whatever is being displayed//which is tracked by topTrack, which starts at 0
                        activeItemInt--;//decrease activeItemInt
                    }
                    else if (activeItemInt == topTrack)
                    {//else if we're at the top of whatever is being displayed
                        if (topTrack == 0)
                        {//if activeItemInt is equal to 0
                         // Debug.Log("3");
                            activeItemInt = itemTags.Count - 1;
                            topTrack += itemTags.Count - visItem;
                            visItem2 = topTrack + visItem;
                            for (int i = 0; i < itemTags.Count; i++)
                            { //set activeItemInt to itemtags.count
                                itemTags[i].AddPos(new Vector3(0, 0, (itemTags.Count - visItem) * -tagSpacer));
                                if (i >= topTrack)
                                {
                                    itemTags[i].visual.SetActive(true);
                                }
                                else
                                {
                                    itemTags[i].visual.SetActive(false);
                                }
                            }

                        }
                        else if (topTrack > 0)
                        { //else if activeItemInt is greater than 0
                          //move all the itemtags down by one
                            activeItemInt--;
                            topTrack--;
                            visItem2--;
                            for (int i = 0; i < itemTags.Count; i++)
                            {
                                itemTags[i].AddPos(new Vector3(0, 0, tagSpacer));
                            }
                            itemTags[activeItemInt].visual.SetActive(true);
                            itemTags[activeItemInt + 9].visual.SetActive(false);
                        }
                    }
                }
            }
            isStep = false;
            DisplayActive();
            //  CycleScroller(increase);
        }

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
    
    void CycleScroller(bool increase){
        if (increase){
            if (scrollSpot < scrollCount - 1){
                scrollSpot++;
            }else{
                scrollSpot = 0;
            }      
        }else if(!increase){
            if (scrollSpot > 0){
                scrollSpot--;
            }else{
                scrollSpot = scrollCount - 1;
            }
                
        }
        scroller.transform.localPosition = scrollPoints[scrollSpot].pos;
    }

    private void ToggleMenu()
    {
        menuOn = !menuOn;
        menuObject.SetActive(menuOn);
    }


}
