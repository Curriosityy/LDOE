

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ProjectileWeapon : Weapon
{
    bool _canFire=true;
    int _rounds = 0;
    Transform minion;
    WeaponItem _weaponItem;
    private void Awake()
    {
        _weaponItem = (WeaponItem)Item;
    }

    public override void Initialize()
    {

    }

    public override void Attack()
    {
        
        if (!_canFire)
            return;
        Debug.Log("FIRE");
        StartCoroutine(FireRate());
        if(_rounds<=0)
        {
            Debug.Log("EMPTY");
            return;
        }
        _rounds--;
        var ray = new Ray(transform.position, minion.forward);
        var range = (_weaponItem.WeaponRange + Random.Range(-5, 5));
        Debug.DrawRay(ray.origin,ray.direction,Color.red,5f);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * range, Color.red, 5f);
        if (Physics.Raycast(ray, out var hit, range))
        {
            var damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.Hit(Random.Range(_weaponItem.DamageRange.x, _weaponItem.DamageRange.y));
        }
    }

    private IEnumerator FireRate()
    {
        _canFire = false;
        yield return new WaitForSeconds(_weaponItem.FireRate);
        _canFire = true;
    }

    public override void Reload()
    {
        Debug.Log("Reload");
        _rounds = _weaponItem.MaxRounds;
    }
}