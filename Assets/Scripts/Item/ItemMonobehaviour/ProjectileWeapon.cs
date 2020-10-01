

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


    public override void Initialize()
    {
        minion = transform.root.GetChild(0);
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
        var range = (_weaponRange + Random.Range(-5, 5));
        Debug.DrawRay(ray.origin,ray.direction,Color.red,5f);
        Debug.DrawLine(ray.origin, ray.origin + ray.direction * range, Color.red, 5f);
        if (Physics.Raycast(ray, out var hit, range))
        {
            var damageable = hit.collider.GetComponent<IDamageable>();
            damageable?.Hit(_damage);
        }
    }

    private IEnumerator FireRate()
    {
        _canFire = false;
        yield return new WaitForSeconds(_fireRate);
        _canFire = true;
    }

    public override void Reload()
    {
        Debug.Log("Reload");
        _rounds = _maxRounds;
    }
}