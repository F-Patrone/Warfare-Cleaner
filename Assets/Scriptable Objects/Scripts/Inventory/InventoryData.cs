using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory Data", menuName = "Inventory/New Inventory")]
public class InventoryData : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    private ItemDatabase database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    private void OnEnable()
    {
#if UNITY_EDITOR
        database = (ItemDatabase)AssetDatabase.LoadAssetAtPath("Assets/Scriptable Objects/Inventorys/Item DataBase.asset", typeof(ItemDatabase));
#else
        database = Resources.Load<ItemDatabase>("Item DataBase");
#endif
    }
    public void AddItem(EquipData _item, int _amount)
    {
       
        for (int i = 0; i < Container.Count; i++)
        {
            if (Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                return;
            }
        }
        Container.Add(new InventorySlot(database.GetId[key: _item], _item, _amount));
    
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath),FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
            file.Close();
        } 
    }


    public void OnAfterDeserialize()
    {
        for (int i = 0; i <Container.Count; i++)
        {
            Container[i].item = database.GetItem[Container[i].id];
        }
    }

    public void OnBeforeSerialize()
    {
    }
}
    [System.Serializable]
public class InventorySlot
{
    public int id;
    public EquipData item;
    public int amount;
    public float weight;
    public int valor;
    public InventorySlot(int _id,EquipData _item, int _amount)
    {
        id = _id;
        item = _item;
        amount = _amount;
        weight = item.peso * amount;
        valor = item.valor * amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    
}