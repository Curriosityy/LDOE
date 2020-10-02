using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> : MonoBehaviour where T:MonoBehaviour
{
    [SerializeField] T _prefab;
    Queue<T> _pool;
    Transform _transform;
    private void Awake()
    {
        _pool = new Queue<T>();
        _transform = transform;
    }
    public void AddObjecToPool(T objectToAdd)
    {
        _pool.Enqueue(objectToAdd);
        objectToAdd.transform.SetParent(_transform);
        objectToAdd.gameObject.SetActive(false);
    }

    public T GetNotActiveObjectFromPool()
    {
        CreateNewObjectIfEmpty();
        return _pool.Dequeue();
    }

    private void CreateNewObjectIfEmpty()
    {
        if (_pool.Count == 0)
            CreateNewObiectInPool();
    }

    public T GetActiveOvjectFromPool()
    {
        CreateNewObjectIfEmpty();
        var obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    private void CreateNewObiectInPool()
    {
        AddObjecToPool(Instantiate(_prefab));
    }
}
