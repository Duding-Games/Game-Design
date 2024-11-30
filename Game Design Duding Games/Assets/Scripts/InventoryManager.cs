using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int prismiteCount = 0;

    public TextMeshProUGUI prismiteText;

    public void AddPrismite(int amount)
    {
        prismiteCount += amount;
        UpdateText();
        Debug.Log("Prismite a�adido. Total: " + prismiteCount);
    }

    public void UpdateText()
    {
        prismiteText.text = "Avaliable Prismite: " + prismiteCount.ToString();
    }
}
