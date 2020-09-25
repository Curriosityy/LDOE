using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnHit : MonoBehaviour, IDamageable
{
    public void Hit(int dmg)
    {
        Destroy(gameObject);
    }
}
