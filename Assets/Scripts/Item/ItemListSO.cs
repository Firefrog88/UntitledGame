using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemList", menuName = "ScriptableObjects/Item/ItemList", order = 1)]
public class ItemListSO : ScriptableObject
{
    [SerializeField] private List<ItemDetails> itemDetails;
}
