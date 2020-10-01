using UnityEngine;

public abstract class ItemMonoBehaviour : MonoBehaviour
{
    public abstract Item Item { get; }
    public abstract void Initialize();

    public void PickUp()
    {

    }
}

public abstract class Weapon: ItemMonoBehaviour
{

    [SerializeField] WeaponItem _item;
    public override Item Item => _item;
    public abstract void Attack();
    public abstract void Reload();
}