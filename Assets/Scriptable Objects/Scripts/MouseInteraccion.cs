using TMPro;
using UnityEngine;

public class MouseInteraccion : MonoBehaviour
{
    public Camera playerCamera; // La cámara desde la cual se proyectará el raycast
    public float rayDistance = 10f; // Distancia máxima del raycast
    public LayerMask layerMask;
    public TextMeshProUGUI objName;
    public GameObject target;
    public InventoryData inventory;
    public Items item;
    public Weapons weapon;
    public Armors armor;
    public Materiales material;
    public Comerciante merchant;

    void Update()
    {
      
            // Generar un raycast desde la posición de la cámara hacia adelante
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance,layerMask))
            {
                // Si el raycast impacta algo
                Debug.Log("Impactó en: " + hit.collider.name);
                Debug.DrawLine(ray.origin, hit.point, Color.red, 1f); // Dibuja una línea temporal para debug
                objName.text = hit.collider.name;
                target = hit.collider.gameObject;
                item = hit.collider.GetComponent<Items>();
                weapon = hit.collider.GetComponent<Weapons>();
                armor = hit.collider.GetComponent<Armors>();
                material = hit.collider.GetComponent<Materiales>();

                
            }
            else
            {
                // Si no impacta nada
                Debug.Log("No impactó nada.");
                objName.text = null;
                target = null;
                item = null;
                weapon = null;
                armor = null;
                material = null;
            }
        if (!merchant.comercioDisponible)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (target != null && item != null)
                {
                    inventory.AddItem(item.item, 1);
                }
                else if (target != null && weapon != null)
                {
                    inventory.AddItem(weapon.weapon, 1);
                }
                else if (target != null && armor != null)
                {
                    inventory.AddItem(armor.armor, 1);
                }
                else if (target != null && material != null)
                {
                    inventory.AddItem(material.material, 1);
                }
                Debug.Log(hit.collider.name + " added to inventory.");
                Destroy(target);


            }
        }
           

    }
}
