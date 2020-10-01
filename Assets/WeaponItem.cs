using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Weapon", order = 0)]
public class WeaponItem : Item
{
    [SerializeField] Vector2Int _damageRange;
    public override ItemSpace Space => ItemSpace.Weapon;

    public override string ToString()
    {
        return base.ToString() + "\n DMG:" + _damageRange.ToString();
    }
}
