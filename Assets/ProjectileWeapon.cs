

using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ProjectileWeapon : Weapon
{
    [SerializeField] float _weaponRange=250;
    [SerializeField] int _damage=5;
    [SerializeField] float _fireRate=0.3f;
    [SerializeField] int _maxRounds = 30;
    bool _canFire=true;
    int _rounds = 0;
    
    public void Initialize()
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
        
        if(Physics.Raycast(new Ray(transform.position, transform.forward), out var hit, (_weaponRange + Random.Range(-5, 5))))
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