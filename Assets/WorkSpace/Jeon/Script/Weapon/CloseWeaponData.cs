using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class CloseWeaponData : MonoBehaviour
{
    [SerializeField] LayerMask ParentLayer;
    [SerializeField] float Power;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable) && collision.gameObject.layer != ParentLayer)
        {
            damageable.TakeDamage(Power);
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 pushDirection = (collision.transform.position - GameManager.Instance.playerMarcine.transform.position).normalized;
                float pushForce = 0.5f;
                Vector2 pushDistance = pushDirection * pushForce;

                // 현재 위치에서 밀어줄 위치로 이동
                Vector2 targetPosition = (Vector2)rb.position + pushDistance;

                // MovePosition을 사용하여 밀어주는 위치로 이동
                rb.MovePosition(targetPosition);
                SoundManager.Instance.PlaySFX(3);
            }
        }
    }

}