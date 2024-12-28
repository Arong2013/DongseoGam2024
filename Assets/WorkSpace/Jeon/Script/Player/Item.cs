using UnityEditor;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public Sprite Icon;
    public string Information;
}


public class Item : MonoBehaviour
{
    [SerializeField] ItemData itemdata;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMarcine>())
        {
            Utils.GetUI<InventoryUI>().AddItem(itemdata);
            GameManager.Instance.SetTrueNextStage?.Invoke();
            gameObject.SetActive(false);
            SoundManager.Instance.PlaySFX(8);
        
        }
    }
}