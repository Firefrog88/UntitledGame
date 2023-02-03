using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour, IDataPersistence
{
    [Header("Inventory UI")]
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private int inventorySize;

    [Header("Slot Components")]
    [SerializeField] private SlotUI slotPrefab;
    [SerializeField] private RectTransform slotsPanel;
    private List <SlotUI> slotsList;

    public bool inventoryOpen { get; private set; }

    private static InventoryManager instance;

    public void LoadData(GameData data)
    {
        
    }

    public void SaveData(GameData data)
    {

    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Inventory Manager. Destroying the newest one");
            Destroy(this.gameObject);
            return;
        }

        slotsList = new List<SlotUI>();

        instance = this;
        InitializeInventoryUI(inventorySize);
    }

    public static InventoryManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        inventoryOpen = false;
        inventoryPanel.SetActive(false);
        StartCoroutine(SelectFirstSlot());
    }

    private void InitializeInventoryUI(int inventorySize)
    {
        for (int i = 0; i < inventorySize; i++)
        {
            SlotUI slotUI = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, slotsPanel);
            slotsList.Add(slotUI);
            //Subscribe slot events to inventory methods
            slotUI.OnItemSelect += HandleItemSelection;
            slotUI.OnItemBeginMove += HandleBeginDrag;
            slotUI.OnItemEndMove += HandleEndDrag;
            slotUI.OnItemDroppedOn += HandleSwap;
            slotUI.OnActionsQueue += HandleShowItemActions;

        }
    }

    private void Update()
    {
        if (!inventoryOpen)
        {
            return;
        }

        // foreach 
    }

    private void HandleItemSelection(SlotUI item)
    {
        Debug.Log(item.name);
    }

    private void HandleBeginDrag(SlotUI item)
    {

    }

    private void HandleEndDrag(SlotUI item)
    {

    }

    private void HandleSwap(SlotUI item)
    {

    }

    private void HandleShowItemActions(SlotUI item)
    {

    }

    public void EnterInventory()
    {
        inventoryOpen = true;
        inventoryPanel.SetActive(true);
    }

    public void ExitInventory()
    {
        inventoryOpen = false;
        inventoryPanel.SetActive(false);
    }

    private IEnumerator SelectFirstSlot()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForSeconds(0.2f);
        EventSystem.current.SetSelectedGameObject(slotsList[0].gameObject);
    }
}
