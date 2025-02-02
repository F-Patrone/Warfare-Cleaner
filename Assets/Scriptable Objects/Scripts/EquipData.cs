using System;
using UnityEngine;
using UnityEngine.UI;

public enum Estado
{
    Pristine,
    Damaged,
    Destroyed,
    Repaired,
    Default
}
public enum ItemType
{
    Weapon,
    Armor,
    Ammunition,
    Material,
    Default
}



[CreateAssetMenu(fileName = "NewEquipData", menuName = "Inventory/EquipData")]
public class EquipData : ScriptableObject
{
    public Image icon;
    public GameObject prefab;
    public string nombre;
    public Estado estado;
    public ItemType itemType;
    [TextArea(5,20)]
    public string description;
    public float peso;
    public float pesoTotal;
    public int valor;
    public int valorTotal;
    public int cantidad;
}