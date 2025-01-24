using System;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public class Item
{
    public string name;
    public int cantidad;
    public float peso;
    public float pesoTotal;
    public float valor;
    public float valorTotal;
    public Item(string name, int cantidad, float peso, float valor)
    {
        this.name = name;
        this.cantidad = cantidad;
        this.peso = peso;
        this.valor = valor;
        this.pesoTotal = peso * cantidad;
        this.valorTotal = valor * cantidad;
    }
}
public class Inventario : MonoBehaviour
{
    public List<Item> items = new List<Item>(); // Lista que representa el inventario

    // M�todo para agregar un �tem al inventario
    public void AgregarItem(string name, int cantidad, float peso, float valor)
    {
        Item itemExistente = items.Find(item => item.name == name);
        if (itemExistente != null)
        {
            itemExistente.cantidad += cantidad;
            Debug.Log($"Se a�adi� {cantidad} al �tem existente: {name}.");
            ActualizarInventario();
        }
        else
        {
            items.Add(new Item(name, cantidad, peso, valor));
            Debug.Log($"Se agreg� un nuevo �tem: {name}.");
            ActualizarInventario();
        }
    }

    // M�todo para eliminar un �tem del inventario
    public void EliminarItem(string name, int cantidad)
    {
        Item itemExistente = items.Find(item => item.name == name);
        if (itemExistente != null)
        {
            if (itemExistente.cantidad > cantidad)
            {
                itemExistente.cantidad -= cantidad;
                Debug.Log($"Se eliminaron {cantidad} del �tem: {name}.");
                ActualizarInventario() ;
            }
            else
            {
                items.Remove(itemExistente);
                Debug.Log($"El �tem {name} fue eliminado completamente del inventario.");
                ActualizarInventario();
            }
        }
        else
        {
            Debug.Log($"El �tem {name} no existe en el inventario.");
        }
    }

    // M�todo para buscar un �tem en el inventario
    public Item BuscarItem(string name)
    {
        return items.Find(item => item.name == name);
    }

    // M�todo para mostrar todos los �tems en el inventario
    public void MostrarInventario()
    {
        Debug.Log("Contenido del inventario:");
        foreach (Item item in items)
        {
            Debug.Log($"Nombre: {item.name}, Cantidad: {item.cantidad}, Peso/Total: {item.peso}/{item.pesoTotal}, Valor/Total: {item.valor}/{item.valorTotal}");
        }
    }

    public void ActualizarInventario()
    {
        foreach (Item item in items)
        {
            item.valorTotal = item.cantidad * item.valor;
            item.pesoTotal = item.cantidad * item.peso;
        }
    }
    // Ejemplo de uso en Start
    /*void Start()
    {
        AgregarItem("Espada", 1, 5.5f, 100f);
        AgregarItem("Poci�n", 5, 0.5f, 25f);
        MostrarInventario();

        EliminarItem("Poci�n", 2);
        MostrarInventario();

        Item buscado = BuscarItem("Espada");
        if (buscado != null)
        {
            Debug.Log($"Se encontr� el �tem: {buscado.name}.");
        }
    }*/

   
}
