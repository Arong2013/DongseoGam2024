using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldChanger : MonoBehaviour
{
    
    bool SetNextGame = false;

    public void SetTrueNextGame()
    {
        SetNextGame = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(SetNextGame && collision.GetComponent<PlayerMarcine>())
        {

        }
    }
}
