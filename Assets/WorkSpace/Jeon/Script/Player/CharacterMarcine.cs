using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMarcine : MonoBehaviour
{
    [SerializeField] float HP;
    [SerializeField] float MoveSpeed;

    protected Rigidbody2D rigidbody2D;
    protected Animator animator;
    protected Weapon playerWeapon;
    protected CharacterState currentBState;


    public Vector2 currentDir { get; protected set;}
    public Rigidbody2D Rigidbody2D => rigidbody2D;

    public void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void Move()
    {
        rigidbody2D.velocity = currentDir * MoveSpeed;
    }
    public void TakeDamage()
    {

    }
    public void ChangePlayerState(CharacterState newState)
    {
        currentBState?.Exit();
        currentBState = newState;
        currentBState.Enter();
    }

    public void SetDir(Vector2 vector2) => currentDir = vector2;
}
