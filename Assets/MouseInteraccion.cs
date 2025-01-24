using TMPro;
using UnityEngine;

public class MouseInteraccion : MonoBehaviour
{
    public Camera playerCamera; // La c�mara desde la cual se proyectar� el raycast
    public float rayDistance = 10f; // Distancia m�xima del raycast
    public LayerMask layerMask;
    public TextMeshProUGUI objName;
    public GameObject target;
    public Inventario inventory;

    void Update()
    {
      
            // Generar un raycast desde la posici�n de la c�mara hacia adelante
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, rayDistance,layerMask))
            {
                // Si el raycast impacta algo
                Debug.Log("Impact� en: " + hit.collider.name);
                Debug.DrawLine(ray.origin, hit.point, Color.red, 2f); // Dibuja una l�nea temporal para debug
                objName.text = hit.collider.name;
                target = hit.collider.gameObject;
            }
            else
            {
                // Si no impacta nada
                Debug.Log("No impact� nada.");
                objName.text = null;
                target = null;
            }
            if(Input.GetMouseButtonDown(0))
            {
                if (target != null)
                {
                    inventory.AgregarItem(hit.collider.name, 1, 2f, 1f);
                    Destroy(target);
                }
            }
            if (Input.GetKeyDown(KeyCode.I)) 
            {
                inventory.MostrarInventario();
            }

    }
}
