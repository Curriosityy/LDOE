using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridItem : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] bool _isInBackpack=true;
    Minion minion;

    public void Initialize(Minion minion)
    {

    }

    private void Equip()
    {
        Debug.Log("Equip");
    }

    private void UnEquip()
    {
        Debug.Log("UnEquip");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Right)
        {
            if(_isInBackpack)
            {
                Equip();
            }
            else
            {
                UnEquip();
            }
        }
    }
}
