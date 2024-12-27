using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : Weapon
{

    [SerializeField] float coolTIme;
    float cunCoolTime;

    public void Start()
    {
        
    }
    private void Update()
    {
        cunCoolTime -= Time.deltaTime;
    }

    public override void Attack()
    {
        if(cunCoolTime <= 0)
        {
            cunCoolTime = coolTIme;
            Vector2 normalizedDirection = playerMarcine.AttackAngle.normalized;
            float angle = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 45);
            gameObject.SetActive(true);
        }
    }
    public override bool IsAttackAble() => cunCoolTime <= 0;
}
