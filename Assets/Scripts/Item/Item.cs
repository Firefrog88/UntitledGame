using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int itemId;
    private SpriteRenderer spriteRenderer;

    public int ItemId { get { return itemId; } set { itemId = value; } }

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if (ItemId != 0 )
        {
            Init(ItemId);
        }
    }

    public void Init(int itemIdParam)
    {
        
    }
}
