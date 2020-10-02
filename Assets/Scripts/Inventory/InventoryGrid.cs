using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    [SerializeField] private Grid _gridPrefab;
    [SerializeField] Vector2 _gridSize = new Vector2(40, 40);
    [SerializeField] Transform _itemParent;
    private GridLayoutGroup _layout;
    Minion _player;
    Backpack _backpack;
    UIItemPool _pool;
    Grid[,] _uiGrid;

    public Grid[,] UiGrid { get => _uiGrid; }

    private void Awake()
    {
        _layout = GetComponent<GridLayoutGroup>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Minion>();
        _backpack = _player.GetComponent<Backpack>();
        _pool = FindObjectOfType<UIItemPool>();
    }

    private void OnEnable()
    {
        _backpack.AddedItem += SpawnItem;
    }
    private void OnDisable()
    {
        _backpack.AddedItem -= SpawnItem;
    }

    private void SpawnItem(Item item,Vector2Int position)
    {
        Debug.Log(position);
        var obj = _pool.GetActiveOvjectFromPool();
        obj.Initialize(item, _player);
        obj.transform.SetParent(_itemParent);
        obj.transform.localPosition = _uiGrid[position.x, position.y].transform.localPosition;
        COLORINVENTORYDEBUG(item, position.x, position.y);
    }

    private void COLORINVENTORYDEBUG(Item itemData, int i, int j)
    {
        for (int k = 0; k < itemData.ItemSize.x; k++)
        {
            for (int n = 0; n < itemData.ItemSize.y; n++)
            {
                _uiGrid[i + n, j + k].Sprite.color=Color.red;
            }
        }
    }

    void Start()
    {
        if (_backpack == null)
            return;
        InitializeUIBackpack();
    }

    private void InitializeUIBackpack()
    {
        _layout.constraintCount = _backpack.X;
        _uiGrid = new Grid[_backpack.X, _backpack.Y];
        for (int i = 0; i < _backpack.X; i++)
        {
            for (int j = 0; j < _backpack.Y; j++)
            {
                _uiGrid[i, j] = Instantiate(_gridPrefab, transform);
            }
        }
    }
}
