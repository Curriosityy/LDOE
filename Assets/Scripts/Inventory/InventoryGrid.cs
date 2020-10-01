using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Grid _gridPrefab;
    [SerializeField] Vector2 _gridSize = new Vector2(40, 40);
    [SerializeField] Transform _itemParent;
    private GridLayoutGroup _layout;
    Minion _player;
    Backpack _backpack;

    Grid[,] _uiGrid;

    public Transform ItemParent { get => _itemParent; }
    public Grid[,] UiGrid { get => _uiGrid; }

    private void Awake()
    {
        _layout = GetComponent<GridLayoutGroup>();
    }

    private void OnEnable()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Minion>();
        _backpack = _player.GetComponent<Backpack>();
    }

    void Start()
    {
        if (_backpack == null)
            return;

        _layout.constraintCount = _backpack.X;
        _uiGrid = new Grid[_backpack.X, _backpack.Y];
        for (int i=0;i < _backpack.X; i++)
        {
            for(int j=0;j < _backpack.Y; j++)
            {
                _uiGrid[i,j]=Instantiate(_gridPrefab, transform);
                _uiGrid[i, j].Initialize(_player);

            }
        }
    }
}
