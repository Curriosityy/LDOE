using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator animator;
    [SerializeField] Transform _pointingFinger;
    [SerializeField] Transform _holdHand;
    [SerializeField] Weapon _weapon;
    float speed=5;
    void Start()
    {
        
    }

    public void SetWeapon(Weapon weapon)
    {
        weapon = _weapon;
        weapon.transform.SetParent(_pointingFinger);
        weapon.transform.position = _pointingFinger.position;
        weapon.Initialize();
        //var direction = _pointingFinger.right+_pointingFinger.up;
        var direction = _pointingFinger.forward;
        weapon.transform.rotation = Quaternion.LookRotation(direction);
    }

    public void Move(float x,float z)
    {
        var normalized = new Vector2(x, z);
        if(normalized.magnitude>1)
        {
            normalized = normalized.normalized;
        }
        characterController.SimpleMove(((transform.forward* normalized.y) +(transform.right* normalized.x))*speed);
        animator.SetFloat("X", x);
        animator.SetFloat("Z", z);
    }

    internal void Reload()
    {
        _weapon.Reload();
    }

    public void LookAt(Vector3 position)
    {
        var dir = position - transform.position;
        characterController.transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
    }

    public void Fire()
    {
        _weapon.Attack();
    }
}
