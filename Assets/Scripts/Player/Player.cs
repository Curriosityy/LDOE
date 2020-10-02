using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    //Minion
    [SerializeField] Minion _minion;
    [SerializeField] Item _cheatItem;
    Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }
    void Update()
    {
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, 1 << 8))
            {
                var point = hit.point;
                point.y = _minion.transform.position.y;
                // var dirVector = (point - _controller.transform.position);
                _minion.LookAt(point);
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {
                _minion.Fire();
            }
        }
        _minion.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _minion.SetWeapon(null);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _minion.Reload();
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            _minion.GetComponent<Backpack>().AddItem(_cheatItem);
        }
    }

}
