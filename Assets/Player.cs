using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Minion
    [SerializeField] CharacterController _controller;
    [SerializeField] Minion _minion;
    Weapon _holdedWeapon;
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, 1 << 8))
        {
            var point = hit.point;
            point.y = _minion.transform.position.y;
            // var dirVector = (point - _controller.transform.position);
            _minion.LookAt(point);
        }
        _minion.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

}

public abstract class Weapon
{
    public abstract void Attack();
    public abstract void Reload();
}