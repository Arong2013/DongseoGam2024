using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;
public class PlayerMarcine : CharacterMarcine
{
    public Weapon weapon;

    public bool isAttackAble => weapon.IsAttackAble();

    public override void Start()
    {
        base.Start(); 
        LinkUi();

    }


    public void Update()
    {
        SetAnimatorValue(CharacterAnimeBoolName.CanWalk, Walkable);
    }
    public void LinkUi() => Utils.SetPlayerMarcineOnUI().ForEach(x => x.Initialize(this));

    public override void Attack()
    {
        weapon.Attack();
        SetAnimatorValue(CharacterAnimeBoolName.CanAttack, false);

    }

    public void FixedUpdate()
    {
        currentBState?.Execute();
    }

    public void EndAttack() => weapon.EndEvent();

    public override void TakeDamage(float DMG)
    {
        
    }
}