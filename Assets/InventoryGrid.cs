using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryGrid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _gridPrefab;
    private GridLayoutGroup _layout;
    Minion _player;
    Backpack _backpack;
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

        for (int i=0;i < _backpack.X; i++)
        {
            for(int j=0;j < _backpack.Y; j++)
            {
                Instantiate(_gridPrefab, transform);
            }
        }
    }
}
