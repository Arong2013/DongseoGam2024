using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject itemSlot;
    ItemData itemData;

    public void AddItem(ItemData itemData)
    {
        GameObject itmes = Instantiate(itemSlot, transform);
        itmes.GetComponent<Image>().sprite = itemData.Icon;
    }
}