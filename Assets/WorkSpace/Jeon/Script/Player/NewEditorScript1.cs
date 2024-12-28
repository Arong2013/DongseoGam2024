using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Thron : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerMarcine>())
        {

        }
        
    }
}