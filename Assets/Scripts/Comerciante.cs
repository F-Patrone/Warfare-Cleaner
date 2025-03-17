using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Comerciante : MonoBehaviour
{
    public GameObject inventoryUi;
    public bool comercioDisponible = false;
    public string recado;
    public bool hayRecado;
    [SerializeField]private EquipData[] leInteresa;
    public TextMeshProUGUI textoRecado;
    public TextMeshProUGUI playerRecado;
    public GameObject playerInv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(comercioDisponible && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            playerInv.SetActive(true);
        }
        if (comercioDisponible && !hayRecado)
        {
            textoRecado.enabled = true;
            PedirRecado();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            comercioDisponible = true;
            inventoryUi.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        comercioDisponible = false;
        inventoryUi.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        playerInv.SetActive(false);
    }
    

    public void PedirRecado()
    {
        int cantidadMax = 0;
        int item = Random.Range(0, leInteresa.Length);
        switch (leInteresa[item].itemType)
        {
            case ItemType.Weapon:
                cantidadMax = 5;
                break;
            case ItemType.Armor:
                cantidadMax = 5;
                break;
            case ItemType.Ammunition:
                cantidadMax = 50;
                break;
            case ItemType.Material:
                cantidadMax = 100;
                break;
            case ItemType.Default:
                cantidadMax = 200;
                break;
            default:
                break;
        }
        int cantidad = Random.Range(1, cantidadMax);

        recado = "Necesito " + cantidad + " de " + leInteresa[item].nombre;
        textoRecado.text = recado;
        hayRecado = true;
    }

    public void AnotarRecado()
    {
        playerRecado.text = recado;
    }
}
