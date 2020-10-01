using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetter : MonoBehaviour
{
    public Transform weapon;
    public Transform hold1;
    public Transform trigger1;
    public Transform hold2;
    public Transform trigger2;

    public void Update()
    {
        WeaponSetterr();
    }
    public void WeaponSetterr()
    {

        weapon.transform.SetParent(trigger1);
        weapon.position = trigger1.position;
        var direction = hold1.transform.position-trigger1.transform.position ;
        direction = direction.normalized;
        weapon.transform.rotation = Quaternion.LookRotation(direction);
    }
    public bool a = false;
    public void OnValidate()
    {
        if (a)
        {
            WeaponSetterr();
            a = false;
        }
    }
}
