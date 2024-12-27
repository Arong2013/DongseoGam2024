using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
public class HeartSlot : MonoBehaviour
{
    [SerializeField] Sprite HeartSpriteA,HeartSpriteB;
    [SerializeField] Image icon;

    public void SetSlot(float currentHP)
    {
        if (currentHP < 0)
        {
            icon.sprite = HeartSpriteB;
        }
        else
            icon.sprite = HeartSpriteA;
    }
}
