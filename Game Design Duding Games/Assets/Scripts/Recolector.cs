using System.Collections;
using UnityEngine;

public class PrismiteCollector : MonoBehaviour
{
    public float collectionRange = 5.0f; // Rango de recolección
    public float collectionInterval = 2.0f; // Tiempo entre recolecciones

    private InventoryManager inventoryManager;

    void Start()
    {
        // Encuentra el InventoryManager en la escena
        inventoryManager = FindObjectOfType<InventoryManager>();

        // Inicia el ciclo de recolección
        StartCoroutine(CollectPrismite());
    }

    IEnumerator CollectPrismite()
    {
        while (true)
        {
            yield return new WaitForSeconds(collectionInterval);

            Debug.Log("Iniciando recolección.");

            // Encuentra todos los Prismite dentro del rango
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, collectionRange);

            Debug.Log($"Se encontraron {hitColliders.Length} colliders dentro del rango.");

            foreach (Collider hitCollider in hitColliders)
            {
                Debug.Log($"Collider detectado: {hitCollider.name}");

                if (hitCollider.CompareTag("Prismite"))
                {
                    Debug.Log("Prismite detectado y recolectado.");

                    inventoryManager.AddPrismite(1);

                    // Llamar al método Interact del objeto Prismite
                    Prismite prismite = hitCollider.GetComponent<Prismite>();
                    if (prismite != null)
                    {
                        prismite.Interact();
                    }
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, collectionRange);

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, collectionRange);
        Gizmos.color = Color.red;

        foreach (Collider hitCollider in hitColliders)
        {
            Gizmos.DrawLine(transform.position, hitCollider.transform.position);
        }
    }
}
