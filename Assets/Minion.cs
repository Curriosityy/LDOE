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
        var direction = _holdHand.transform.position - _pointingFinger.transform.position;
        direction = direction.normalized;
        weapon.transform.rotation = Quaternion.LookRotation(direction);
    }

    public void Move(float x,float z)
    {
        characterController.SimpleMove(((transform.forward*z)+(transform.right*x))*speed);
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
