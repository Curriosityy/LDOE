using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Minion
    [SerializeField] CharacterController _controller;
    float _speed = 3;
    void Update()
    {
        var moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime* _speed;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out var hit,Mathf.Infinity,1<<8))
        {
            var point = hit.point;
            point.y = _controller.transform.position.y;
            var dirVector = (point - _controller.transform.position);
            _controller.transform.rotation = Quaternion.LookRotation(dirVector.normalized, Vector3.up);
            Debug.DrawRay(_controller.transform.position, dirVector,Color.red);
        }
        _controller.Move(moveVector);

    }
}
