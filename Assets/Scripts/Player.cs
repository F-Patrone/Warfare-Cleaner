using UnityEngine;

public class Player : MonoBehaviour
{
    public InventoryData inventory;

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
    }


}
