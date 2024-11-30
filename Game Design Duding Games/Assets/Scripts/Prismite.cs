using UnityEngine;

public class Prismite : MonoBehaviour
{
    public float growthRate = 0.1f; // Velocidad a la que crece el objeto
    public float shrinkAmount = 0.5f; // Cantidad que reduce al interactuar

    private void Update()
    {
        // Aumentar el tamaño del objeto gradualmente
        transform.localScale += Vector3.one * growthRate * Time.deltaTime;
        if (transform.localScale.x > 25)
        {
            transform.localScale = Vector3.one * 25;
        }
    }

    public void Interact()
    {
        // Reducir el tamaño del objeto
        transform.localScale -= Vector3.one * shrinkAmount;
        
        // Verificar si el tamaño es menor o igual a 0
        if (transform.localScale.x <= 0 || transform.localScale.y <= 0 || transform.localScale.z <= 0)
        {
            Destroy(gameObject);
        }
    }
}

