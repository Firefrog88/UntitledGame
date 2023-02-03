using UnityEngine;

[System.Serializable]
public class ItemDetails
{
    public int itemId;
    public ItemType itemType;
    public string itemDescription;
    public Sprite itemSprite;
    public string itemLongDescription;
    public short itemUseGridRadius;
    public float itemUseRadius;
    public bool isStartingItem;
    public bool pickable; // Can be picked up from ground
    public bool droppable; // Can be dropped from inventory
    public bool edible; // Can be eaten/consumed
    public bool portable; // Can be carried in inventory
}
