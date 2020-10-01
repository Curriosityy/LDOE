using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Weapon", order = 0)]
public class WeaponItem : Item
{
    [SerializeField] Vector2Int _damageRange;
    [SerializeField] float _weaponRange = 250;
    [SerializeField] float _fireRate = 0.3f;
    [SerializeField] int _maxRounds = 30;
    public override ItemSpace Space => ItemSpace.Weapon;

    public override string ToString()
    {
        return base.ToString() + "\n DMG:" + _damageRange.ToString();
    }
}
