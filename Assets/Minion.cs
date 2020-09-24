using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Minion : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Animator animator;
    float speed=5;
    void Start()
    {
        
    }

    public void Move(float x,float z)
    {
        characterController.SimpleMove(((transform.forward*z)+(transform.right*x)).normalized*speed);
        animator.SetFloat("X", x);
        animator.SetFloat("Z", z);
    }

    public void LookAt(Vector3 position)
    {
        var dir = position - transform.position;
        characterController.transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
    }
}
