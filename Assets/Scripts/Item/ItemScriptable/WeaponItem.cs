using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Weapon", order = 0)]
public class WeaponItem : Item
{
    [SerializeField] Vector2Int _damageRange;
    [SerializeField] float _weaponRange = 250;
    [SerializeField] float _fireRate = 0.3f;
    [SerializeField] int _maxRounds = 30;
    public override ItemSpace Space => ItemSpace.Weapon;

    public float WeaponRange { get => _weaponRange; }
    public float FireRate { get => _fireRate; }
    public int MaxRounds { get => _maxRounds; }
    public Vector2Int DamageRange { get => _damageRange; }

    public override string ToString()
    {
        return base.ToString() 
            + "\n DMG:" + _damageRange
            + "\n Range:" + _weaponRange+" m"
            + "\n Fire rate:" + _fireRate +" s"
            + "\n Max Rounds:" + _maxRounds;
    }
}
