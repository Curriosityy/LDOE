using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    private static PrefabManager _instance;
    [SerializeField] private InventoryItemUI _prefabInventoryItem;

    public static PrefabManager Instance =>_instance;
    public InventoryItemUI PrefabInventoryItem { get => _prefabInventoryItem; }


    private void Awake()
    {
        if(_instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
