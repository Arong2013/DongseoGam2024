using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Thron : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMarcine>())
        {
            // Implement any behavior for when the player enters the trigger zone, if needed.
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<PlayerMarcine>(out PlayerMarcine playerMarcine))
        {
            // Apply damage to the player
            playerMarcine.TakeDamage(1f);
            Vector2 forceDirection = (collision.transform.position - transform.position).normalized; // Direction away from the object
            float forceMagnitude = 5f; // Adjust the force magnitude as needed
            playerMarcine.Rigidbody2D.AddForce(forceDirection * forceMagnitude, ForceMode2D.Impulse); // Apply an impulse force
        }
    }
}
