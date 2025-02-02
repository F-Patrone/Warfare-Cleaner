using UnityEngine;

[CreateAssetMenu(fileName = "New Material Object", menuName = "Inventory/EquipData/Material")]
public class MaterialObject : EquipData 
{ 
    private void Awake()
    {
        itemType = ItemType.Material;
        estado = Estado.Default;
    }
}
