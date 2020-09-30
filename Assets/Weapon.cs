using UnityEngine;

public abstract class Weapon:MonoBehaviour
{
    public abstract void Initialize();
    public abstract void Attack();
    public abstract void Reload();
}