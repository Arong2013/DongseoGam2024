using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartUI : MonoBehaviour, IPlayerUesableUI, IObserver
{
    [SerializeField] HeartSlot heartSlot; // HeartSlot 프리팹
    [SerializeField] Transform parent; // HeartSlot을 배치할 부모 오브젝트

    CharacterMarcine playermarcine; // 플레이어의 캐릭터 마시네
    List<HeartSlot> heartSlots; // HeartSlot 리스트

    float MaxHP;

    public void Initialize(PlayerMarcine playerMarcine)
    {
        this.playermarcine = playerMarcine;
        MaxHP = playermarcine.HP;
        playerMarcine.RegisterObserver(this);
        CreateHeartSlots(playerMarcine.HP);
 
    }

    public void UpdateObserver()
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
        CreateHeartSlots(playermarcine.HP);
    }

    private void CreateHeartSlots(float hp)
    {
        var curHP = hp;
        for (var i = 0; i < MaxHP; i++)
        {
            curHP--;
            GameObject gameObject = Instantiate(heartSlot.gameObject, parent);
            gameObject.GetComponent<HeartSlot>().SetSlot(curHP);
        }
    }
}
