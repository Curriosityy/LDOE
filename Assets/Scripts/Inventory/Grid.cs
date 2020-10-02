using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Grid : MonoBehaviour
{
    [SerializeField] Image _sprite;
    [SerializeField] ItemSpace _space;

    public Image Sprite { get => _sprite; }
}
