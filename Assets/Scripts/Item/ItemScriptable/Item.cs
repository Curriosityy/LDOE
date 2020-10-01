﻿using UnityEngine;

public abstract class Item:ScriptableObject
{
    [SerializeField] string _itemName;
    [SerializeField] Vector2Int _itemSize;
    [SerializeField] Sprite _icon;
    [SerializeField] ItemMonoBehaviour _itemPrefab;
    [SerializeField] string _information;
    ItemSpace _space;
    
    public Vector2Int ItemSize { get => _itemSize; }
    public Sprite Icon { get => _icon; }
    public ItemMonoBehaviour ItemPrefab { get => _itemPrefab; }
    public abstract ItemSpace Space { get; }
    public string ItemName { get => _itemName; }

    public virtual ItemMonoBehaviour InstantiateInWord()
    {
        return Instantiate(_itemPrefab);
    }
    public virtual InventoryItemUI InstantiateToInInventory()
    {
        return null;
    }
    public override string ToString()
    {
        return _information;
    }
}
