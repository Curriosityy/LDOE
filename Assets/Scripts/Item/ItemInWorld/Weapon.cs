using UnityEngine;

public abstract class Weapon: ItemMonoBehaviour
{

    [SerializeField] WeaponItem _item;
    public override Item Item => _item;
    public abstract void Attack();
    public abstract void Reload();
}