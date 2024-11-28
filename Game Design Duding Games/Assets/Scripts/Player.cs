using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float interactRange = 2.0f; // Rango de interacción
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        // Detectar si el jugador presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E presionada");
            Interact();
        }
    }

    void Interact()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Prismite"))
            {
                Debug.Log("Prismite obtenido");
                inventoryManager.AddPrismite(1);

                // Destruye el material cada x recolecciones
                //Destroy(hitCollider.gameObject);
                break;
            }

            // Hacer lo mismo para otros materiales
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
