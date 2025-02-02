using UnityEngine;

[CreateAssetMenu(fileName = "New Item Object", menuName = "Inventory/EquipData/Item")]
public class ItemObject : EquipData
{
    private void Awake()
    {
        itemType = ItemType.Default;
        estado = Estado.Default;
    }
}
