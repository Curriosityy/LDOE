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

    public Transform ItemParent { get => _itemParent; }
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
        _backpack.AddedItem += OnAddItem;
    }
    private void OnDisable()
    {
        _backpack.AddedItem -= OnAddItem;
    }
    private void OnAddItem(Item arg1, Vector2Int arg2)
    {
        throw new System.NotImplementedException();
    }

    private void SpawnItem(Item item,Vector2Int position)
    {

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
