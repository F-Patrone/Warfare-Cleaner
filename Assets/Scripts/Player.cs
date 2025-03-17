using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryData inventory;
    public GameObject inventoryUi;

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            inventory.Save();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            inventory.Load();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!inventoryUi.activeInHierarchy)
            {
                inventoryUi.SetActive(true);
            }
            else inventoryUi.SetActive(false);
        }
    }


}
