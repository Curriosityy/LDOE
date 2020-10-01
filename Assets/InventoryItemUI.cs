using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI:MonoBehaviour,IDragHandler,IDropHandler,IPointerDownHandler
{
    [SerializeField] Vector2Int size;
    [SerializeField] Image _image;
    Item _data;
    Minion _player;
    public void Initialize(Item item,Minion player)
    {
        _data = item;
        _player = player;
        _image.sprite = _data.Icon;
        size = item.ItemSize;
        GetComponent<RectTransform>().sizeDelta = size * 40;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("DRAG");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DROP");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Right)
        {

        }
    }

    public void Equip()
    {

    }

    public void Unequip()
    {

    }


}
