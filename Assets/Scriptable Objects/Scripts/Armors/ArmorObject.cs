using UnityEngine;

public enum ArmorType
{
    Light,
    Medium,
    Heavy,
    Default
}
public enum ArmorPiece
{
    Head,
    Chest,
    Legs,
    Foots,
    Hands,
    Default
    
}

[CreateAssetMenu(fileName = "New Armor Object", menuName = "Inventory/EquipData/Armor")]
public class ArmorObject : EquipData
{
    public ArmorType armorType = ArmorType.Default;
    public ArmorPiece armorPiece = ArmorPiece.Default;

    private void Awake()
    {
        itemType = ItemType.Armor;
        estado = Estado.Default;
    }
}
