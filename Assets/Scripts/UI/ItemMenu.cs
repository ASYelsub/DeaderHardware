using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemMenu : MonoBehaviour
{
    [Header("Raycast Stuff")]
    [SerializeField] private Camera cam;
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
    private List<EditorItem> allEditor = new List<EditorItem>();
    [SerializeField]
    private List<Item> allItems = new List<Item>();
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

    private Item activeItem;
    private int activeItemVal;


    [System.Serializable]
    public class EditorItem
    {
        public bool collected;
        public string itemName;
        public string itemDecription;
    }


    public class Item{
        [HideInInspector] public bool isActive;
        public bool collected;
        public string itemDecription;
        public string itemName;
        [HideInInspector]public ItemTag tag;
        private Material activeMat;
        private Material inactiveMat;
        private GameObject textHolder;
        public Item(GameObject tagPrefab, GameObject textHolder, GameObject tagParent, List<ItemTag> itemTags,
            string desc, string name, bool collected,
            Material activeMat, Material inactiveMat)
        {
            this.textHolder = textHolder;
            this.activeMat = activeMat;
            this.inactiveMat = inactiveMat;
            this.collected = collected;
            this.itemDecription = desc;
            this.itemName = name;
            tag = new ItemTag(tagPrefab, tagParent, collected, isActive, itemName);
            itemTags.Add(tag);
        }

        public void SetActiveState(){
            if (this.isActive)
            {
                tag.visual.GetComponent<MeshRenderer>().material = activeMat;
                textHolder.GetComponent<TextMeshPro>().text = itemDecription;
            }else
                tag.visual.GetComponent<MeshRenderer>().material = inactiveMat;

        }

    }
    public class ItemTag{
        [HideInInspector]public Vector3 tagPos;
        [HideInInspector] public GameObject visual;
        [HideInInspector] public TextMeshPro tagText;
        [HideInInspector] public GameObject model;
        
        
        public ItemTag(GameObject tagPrefab, GameObject tagParent,
            bool collected, bool active, string name){
            
            tagPos = new Vector3(0, 0, 0);
            visual = Instantiate(tagPrefab, tagParent.transform,false);
            tagText = visual.GetComponentInChildren<TextMeshPro>();
            tagText.text = name;
            visual.SetActive(false);
        }
        public void SetPos(Vector3 pos)
        {
            this.tagPos = pos;
            visual.GetComponent<Transform>().localPosition = tagPos;
        }
        public void AddPos(Vector3 pos)
        {
            this.tagPos += pos;
            visual.GetComponent<Transform>().localPosition = tagPos;
        }
       
    }
   
    private void Start(){
        menuOn = false;
        menuIsMoving = false;
        menuObject.SetActive(menuOn);
        AddEditorItems();
        DisplayCollected();
        SetActive(0);
    }
    void MoveActive(bool increase)
    {
        if (increase){
            if(activeItemVal == collectedItems.Count - 1)
                activeItemVal = 0;
           else
                activeItemVal = activeItemVal + 1;
        }else{
            if(activeItemVal == 0)
                activeItemVal = collectedItems.Count - 1;
            else
                activeItemVal = activeItemVal - 1;
            
        }
        for (int i = 0; i < collectedItems.Count; i++){
            if(i == activeItemVal)
                collectedItems[i].isActive = true;
            else
                collectedItems[i].isActive = false;
            
            collectedItems[i].SetActiveState();
        }
    }
    void SetActive(int f){
        for (int i = 0; i < collectedItems.Count; i++){
            if (i == f){
                collectedItems[i].isActive = true;
            }else{
                collectedItems[i].isActive = false;
            }
            collectedItems[i].SetActiveState();
        }
    }
    void DisplayCollected(){
        for (int i = 0; i < collectedItems.Count; i++){
            print(collectedItems[i].itemName);
            collectedItems[i].tag.visual.SetActive(true);
            collectedItems[i].tag.SetPos(new Vector3(2.4f, 0.001f, -4.153f));
            if (i != 0){
                collectedItems[i].tag.AddPos(new Vector3(0,0,i));
            }
        }
    }

    void AddEditorItems()
    {
        for (int i = 0; i < allEditor.Count; i++)
        {
            allItems.Add(new Item(tagPrefab, rightDesc, tagParent, itemTags,
                allEditor[i].itemDecription, allEditor[i].itemName, allEditor[i].collected,activeMat,inactiveMat));
        }
        SortItems();
    }
    void SortItems()
    {
        collectedItems.Clear();
        for (int i = 0; i < allItems.Count; i++)
        {
            if (allItems[i].collected)
            {
                collectedItems.Add(allItems[i]);
            }
        }
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
        if (menuOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                point = (new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                point.z = -10;
                ButtonRay();
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                MoveActive(true);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                MoveActive(false);
            }
        }
    }

    

    private void ToggleMenu(){
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
