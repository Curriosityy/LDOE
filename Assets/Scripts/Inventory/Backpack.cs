using System;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public event Action<Item,Vector2Int> AddedItem;

    [SerializeField] int _x;
    [SerializeField] int _y;
    Item[,] _inventory;
    Dictionary<Vector2Int, Item> itemInInventory;
    public int X { get => _x; }
    public int Y { get => _y; }
    public Item[,] Inventory { get => _inventory; set => _inventory = value; }

    

    // Start is called before the first frame update
    void Awake()
    {
        itemInInventory = new Dictionary<Vector2Int, Item>();
        _inventory = new Item[_x, _y];
    }

    public bool AddItem(Item itemData)
    {
        for(int i=0;i<_x;i++)
        {
            for(int j=0;j<_y;j++)
            {
                if(_inventory[i,j]==null)
                {
                    if(CanBeAdded(itemData, i, j))
                    {
                        itemInInventory.Add(new Vector2Int(i,j),itemData);
                        AddToArray(itemData,i,j);

                        AddedItem?.Invoke(itemData, new Vector2Int(i, j));
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public Item RemoveItem(Vector2Int itemPosition)
    {
        var item = itemInInventory[itemPosition];
        itemInInventory.Remove(itemPosition);
        RemoveFromArray(itemPosition.x, itemPosition.y);
        return item;
    }

    private bool CanBeAdded(Item itemData, int i, int j)
    {
        for (int k = 0; k < itemData.ItemSize.y; k++)
        {
            for (int n = 0; n < itemData.ItemSize.x; n++)
            {
                if (_inventory[i + n, j + k] != null)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void AddToArray(Item itemData, int i, int j)
    {
        for (int k = 0; k < itemData.ItemSize.y; k++)
        {
            for (int n = 0; n < itemData.ItemSize.x; n++)
            {
                _inventory[i + n, j + k] = itemData;
            }
        }
    }

    private void RemoveFromArray(int i, int j)
    {
        AddToArray(null, i, j);
    }


}
