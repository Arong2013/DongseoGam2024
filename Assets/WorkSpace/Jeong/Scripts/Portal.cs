using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("스테이지 이동");
        }
    }
}
