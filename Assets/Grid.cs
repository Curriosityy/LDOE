using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Grid : MonoBehaviour
{
    [SerializeField] Image _sprite;
    [SerializeField] ItemSpace _space;
    
    [SerializeField] 
    Minion _minion;


    public void Initialize(Minion minion,ItemSpace itemSpace=ItemSpace.All)
    {
        _minion = minion;
        _space = itemSpace;
    }
}
