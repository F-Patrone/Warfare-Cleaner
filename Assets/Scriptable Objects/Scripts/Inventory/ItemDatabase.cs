using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory/Item Database")]
public class ItemDatabase : ScriptableObject,ISerializationCallbackReceiver 
{
    public EquipData[] Items;
    public Dictionary<EquipData, int> GetId = new Dictionary<EquipData, int>();
    public Dictionary<int, EquipData> GetItem = new Dictionary<int, EquipData>();

    public void OnAfterDeserialize()
    {
        GetId = new Dictionary<EquipData, int>();
        GetItem = new Dictionary<int, EquipData>();
        for (int i = 0; i < Items.Length; i++)
        {
            GetId.Add(Items[i], i);
            GetItem.Add(i, Items[i]);
        }
    }
    public void OnBeforeSerialize()
    { 
    
    }
}
