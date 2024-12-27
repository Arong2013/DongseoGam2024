using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartUI : MonoBehaviour, IPlayerUesableUI, IObserver
{
    [SerializeField] HeartSlot heartSlot; // HeartSlot ������
    [SerializeField] Transform parent; // HeartSlot�� ��ġ�� �θ� ������Ʈ

    CharacterMarcine playermarcine; // �÷��̾��� ĳ���� ���ó�
    List<HeartSlot> heartSlots; // HeartSlot ����Ʈ

    public void Initialize(CharacterMarcine playerMarcine)
    {
        this.playermarcine = playerMarcine;
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
        for (var i = 0; i < hp; i++)
        {
            hp--;
            GameObject gameObject = Instantiate(heartSlot.gameObject, parent);
            gameObject.GetComponent<HeartSlot>().SetSlot(hp);
        }
    }
}
