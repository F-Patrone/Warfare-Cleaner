using UnityEngine;

public enum WeaponType
{
    Bow,
    Dagger,
    Sword,
    Axe,
    Hammer,
    PoleArm,
    Default
}
[CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory/EquipData/Weapon")]
public class WeaponObject : EquipData
{
    public WeaponType weaponType = WeaponType.Default;

    private void Awake()
    {
        itemType = ItemType.Weapon;

    }
}
