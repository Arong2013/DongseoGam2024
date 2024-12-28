using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Thron : MonoBehaviour
{

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMarcine>(out PlayerMarcine playerMarcine))
        {
            playerMarcine.TakeDamage(1f);
          
        }
    }
}
