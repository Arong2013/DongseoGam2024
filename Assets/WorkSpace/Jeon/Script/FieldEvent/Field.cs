using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    [SerializeField] GameObject ItemOBJ;

    public void Start()
    {
        GameManager.Instance.ItemEnable += SetTrueNextGame;
    }

    public void SetTrueNextGame()
    {
        ItemOBJ.gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
