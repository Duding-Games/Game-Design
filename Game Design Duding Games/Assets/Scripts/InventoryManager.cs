using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int prismiteCount = 0;

    public void AddPrismite(int amount)
    {
        prismiteCount += amount;
        Debug.Log("Prismite añadido. Total: " + prismiteCount);
    }
}
