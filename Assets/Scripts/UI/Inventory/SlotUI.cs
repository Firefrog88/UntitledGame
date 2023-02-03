using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class SlotUI : MonoBehaviour
{
    [Header("Slot Components")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text quantityTxt;
    [SerializeField] private Image borderImage;

    public event Action<SlotUI> OnItemSelect, OnItemDroppedOn, OnItemBeginMove, OnItemEndMove, OnActionsQueue;

    private bool empty = true;

    public void Awake()
    {
        ResetData();
        Deselect();
    }

    public void SetData(Sprite sprite, int quantity)
    {
        itemImage.gameObject.SetActive(true);
        itemImage.sprite = sprite;
        quantityTxt.text = quantity + "";
        empty = false;
    }

    private void ResetData()
    {
        itemImage.gameObject.SetActive(false);
        empty = true;
    }

    public void Select()
    {
        borderImage.enabled = true;
    }

    public void Deselect()
    {
        borderImage.enabled = false;
    }

    public void OnBeginDrag()
    {
        if (empty)
            return;
        OnItemBeginMove?.Invoke(this);
    }

    public void OnDrop()
    {
        OnItemDroppedOn?.Invoke(this);
    }

    public void OnEndDrag()
    {
        OnItemEndMove.Invoke(this);
    }

    public void OnPointerClick(BaseEventData data)
    {
        PointerEventData pointerData = (PointerEventData)data;
        if (pointerData.button == PointerEventData.InputButton.Right)
        {
            OnActionsQueue?.Invoke(this);
        }
        else
        {
            OnItemSelect?.Invoke(this);
        }
    }
}