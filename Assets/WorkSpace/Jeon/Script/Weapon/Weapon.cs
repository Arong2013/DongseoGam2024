using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public PlayerMarcine playerMarcine;
    public abstract void Attack();
    public void EndEvent() => gameObject.SetActive(false);
    public abstract bool IsAttackAble();
}
