using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject collectorPrefab;

    public float interactRange = 2.0f; // Rango de interacción
    private InventoryManager inventoryManager;
    private int item = 1;

    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    void Update()
    {
        // Detectar si el jugador presiona la tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("E presionada");
            Interact();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q presionada");
            CreateRecolector();
        }
    }

    void Interact()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Prismite"))
            {
                inventoryManager.AddPrismite(1 * item);

                // Llamar al método Interact del objeto Prismite
                Prismite prismite = hitCollider.GetComponent<Prismite>();
                if (prismite != null)
                {
                    prismite.Interact();
                }

                break;
            }
        }
    }

    void CreateObject()
    {
        if (inventoryManager.prismiteCount >= 10)
        {
            inventoryManager.prismiteCount -= 10;
            Debug.Log("Prismite consumido. Total restante: " + inventoryManager.prismiteCount);

            item += 2;
        }
        else Debug.Log("No tienes suficiente Prismite para crear el objeto.");
    }

    void CreateRecolector()
    {
        if (inventoryManager.prismiteCount >= 10)
        {
            // Resta Prismite del inventario
            inventoryManager.prismiteCount -= 10;

            inventoryManager.UpdateText();
            Debug.Log("Prismite consumido. Total restante: " + inventoryManager.prismiteCount);
            Debug.Log("Recolector creado");

            // Instancia el recolector en la posición del jugador con un ligero desplazamiento
            Vector3 spawnPosition = transform.position + new Vector3(0, 0, 2); // Desplazar al frente
            Instantiate(collectorPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.Log("No tienes suficiente Prismite para crear el objeto.");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}
