using UnityEngine;

public class Backpack : MonoBehaviour
{
    [SerializeField] int _x;
    [SerializeField] int _y;
    Item[,] _inventory;
    public int X { get => _x; }
    public int Y { get => _y; }
    public Item[,] Inventory { get => _inventory; set => _inventory = value; }

    // Start is called before the first frame update
    void Awake()
    {
        _inventory = new Item[_x, _y];
    }

    public void AddItem(Item itemData)
    {
        for(int i=0;i<_x;i++)
        {
            for(int j=0;j<_y;j++)
            {
                if(_inventory[i,j]==null)
                {
                    if(CanBeAdded(itemData, i, j))
                    {
                        return;
                    }
                }
            }
        }
    }

    private bool CanBeAdded(Item itemData, int i, int j)
    {
        for (int k = 0; k < itemData.ItemSize.y; k++)
        {
            for (int n = 0; n < itemData.ItemSize.x; n++)
            {
                if (_inventory[i, j] != null)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
