using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComercioOpciones : MonoBehaviour
{
    public InventoryData playerInv;
    public InventoryData comercianteInv;
    public TMP_InputField selCantidad;
    public int cantidad;

    public int playerDinero;
    public int comercianteDinero;


    public void Vender(EquipData _item)
    {
        cantidad = int.Parse(selCantidad.text);

        // Buscar si el jugador tiene el objeto en el inventario
        InventorySlot playerSlot = playerInv.Container.Find(slot => slot.item == _item);

        if (playerSlot == null || playerSlot.amount < cantidad)
        {
            Debug.Log("No tienes suficientes objetos para vender.");
            return;
        }

        // Calcular el precio total de la venta
        int precioTotal = _item.valor * cantidad;

        // Verificar si el comerciante tiene suficiente dinero
        if (comercianteDinero < precioTotal)
        {
            Debug.Log("El comerciante no tiene suficiente dinero.");
            return;
        }

        // Realizar la transacción
        playerInv.RemoveItem(_item, cantidad);
        comercianteInv.AddItem(_item, cantidad);

        // Transferir dinero
        playerDinero += precioTotal;
        comercianteDinero -= precioTotal;

        Debug.Log($"Vendiste {cantidad} de {_item.nombre} por {precioTotal} monedas.");
    }

    public void Comprar(EquipData _item)
    {
        cantidad = int.Parse(selCantidad.text);

        // Buscar si el comerciante tiene el objeto en su inventario
        InventorySlot comercianteSlot = comercianteInv.Container.Find(slot => slot.item == _item);

        if (comercianteSlot == null || comercianteSlot.amount < cantidad)
        {
            Debug.Log("El comerciante no tiene suficientes objetos para vender.");
            return;
        }

        // Calcular el precio total de la compra
        int precioTotal = _item.valor * cantidad;

        // Verificar si el jugador tiene suficiente dinero
        if (playerDinero < precioTotal)
        {
            Debug.Log("No tienes suficiente dinero para comprar.");
            return;
        }

        // Realizar la transacción
        comercianteInv.RemoveItem(_item, cantidad);
        playerInv.AddItem(_item, cantidad);

        // Transferir dinero
        playerDinero -= precioTotal;
        comercianteDinero += precioTotal;

        Debug.Log($"Compraste {cantidad} de {_item.nombre} por {precioTotal} monedas.");
    }
}
