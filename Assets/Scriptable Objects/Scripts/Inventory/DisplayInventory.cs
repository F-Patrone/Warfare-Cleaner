using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayInventory : MonoBehaviour
{
    public InventoryData inventory;

    public int XStart;
    public int YStart;
    public int Y_Space_Distance;
    public int X_Space_Distance;
    public int columnas;

    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();

    }

    public void CreateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InventorySlot slot = inventory.Container[i];

            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            GameObject nombreObj = FindChildByName(obj.transform, "Nombre")?.gameObject;
            if (nombreObj != null)
                nombreObj.GetComponent<TextMeshProUGUI>().text = slot.item.nombre;
            else
                Debug.Log("Nombre no encontrado");

            GameObject estado = FindChildByName(obj.transform, "Estado")?.gameObject;
            if (estado != null)
                estado.GetComponent<TextMeshProUGUI>().text = slot.item.estado.ToString();
            else
                Debug.Log("Estado no encontrado");

            GameObject cantidad = FindChildByName(obj.transform, "Cantidad")?.gameObject;
            if (cantidad != null)
                cantidad.GetComponent<TextMeshProUGUI>().text = slot.amount.ToString();
            else
                Debug.Log("Cantidad no encontrado");

            GameObject peso = FindChildByName(obj.transform, "Peso")?.gameObject;
            if (peso != null)
                peso.GetComponent<TextMeshProUGUI>().text = slot.weight.ToString();
            else
                Debug.Log("Peso no encontrado");
        }
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(XStart, YStart - (Y_Space_Distance * i / columnas), 0f);
    }
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {

                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
               
            }
            else
            {
                InventorySlot slot = inventory.Container[i];

                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);


                GameObject nombreObj = FindChildByName(obj.transform, "Nombre")?.gameObject;
                if (nombreObj != null)
                    nombreObj.GetComponent<TextMeshProUGUI>().text = slot.item.nombre;
                else
                    Debug.Log("Nombre no encontrado");

                GameObject estado = FindChildByName(obj.transform, "Estado")?.gameObject;
                if (estado != null)
                    estado.GetComponent<TextMeshProUGUI>().text = slot.item.estado.ToString();
                else
                    Debug.Log("Estado no encontrado");

                GameObject cantidad = FindChildByName(obj.transform, "Cantidad")?.gameObject;
                if (cantidad != null)
                    cantidad.GetComponent<TextMeshProUGUI>().text = slot.amount.ToString();
                else
                    Debug.Log("Cantidad no encontrado");

                GameObject peso = FindChildByName(obj.transform, "Peso")?.gameObject;
                if (peso != null)
                    peso.GetComponent<TextMeshProUGUI>().text = slot.weight.ToString();
                else
                    Debug.Log("Peso no encontrado");

                // Agregar el objeto a la lista para futuras actualizaciones
                itemsDisplayed.Add(slot, obj);
            }
        }
    }
    Transform FindChildByName(Transform parent, string childName)
    {
        foreach (Transform child in parent.GetComponentsInChildren<Transform>(true)) // true incluye los inactivos
        {
            if (child.name == childName)
            {
                return child;
            }
        }
        return null; // Si no encuentra el child, devuelve null
    }
}
