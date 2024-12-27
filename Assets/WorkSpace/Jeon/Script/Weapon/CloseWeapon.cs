using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : Weapon
{
    [SerializeField] LayerMask ParentLayer;
    [SerializeField] float Power;

    public override void Attack()
    {
        gameObject.SetActive(true);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable damageable) && collision.gameObject.layer != ParentLayer)
        {
            damageable.TakeDamage(Power);
        }   
    }
    public void EventEvent() => gameObject.SetActive(false);
}
