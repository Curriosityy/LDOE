

using UnityEngine;

public class ProjectileWeapon : Weapon
{
    public override void Attack()
    {
        Debug.Log("FIREEEE");
    }

    public override void Reload()
    {
        Debug.Log("Reload");
    }
}