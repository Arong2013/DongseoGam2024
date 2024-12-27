using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public enum CharacterAnimeBoolName
{
    WalkSide,
    CanWalk
}
public enum CharacterAnimeFloatName
{
    ChargingCount,
    SpeedCount,
    WalkX,
    WalkY
}
public enum CharacterAnimeIntName
{
    AttackType,
    HitType,
    RoarType,
    InteractionType
}
public enum MovementType
{
    Walk = 1,
    Jump = 2,
    Roll = 3,
    Falling = 4,
}

public enum InteractionType
{
    Climb = 1,
    Throw = 2
}

public interface IDamageable
{
    public void TakeDamage(float DMG);
}


public abstract class CharacterMarcine : MonoBehaviour, IDamageable,ISubject
{
    List<IObserver> observers = new List<IObserver>();


    public float HP;
    public float MoveSpeed;

    protected Rigidbody2D rigidbody2D;
    protected Animator animator;
    protected Weapon playerWeapon;
    protected CharacterState currentBState;
    protected SpriteRenderer spriteRenderer;
    


    protected CharacterAnimatorHandler characterAnimator;



    public bool Walkable;
    public Vector2 currentDir { get; protected set;}
    public Vector2 AttackAngle { get; protected set;}
    public Rigidbody2D Rigidbody2D => rigidbody2D;

    public virtual void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterAnimator = new CharacterAnimatorHandler(animator);


    }
    public void Move()
    {
        Vector2 moveDirection = currentDir.normalized * MoveSpeed;
        Rigidbody2D.velocity = moveDirection;
        if (currentDir.x != 0)
        {
            spriteRenderer.flipX = currentDir.x > 0;
        }
        SetAnimatorValue(CharacterAnimeFloatName.WalkX,currentDir.x);
        SetAnimatorValue(CharacterAnimeFloatName.WalkY, currentDir.y);
        rigidbody2D.velocity = currentDir * MoveSpeed;
    }

    public void Attack()
    {

    }
    public void TakeDamage(float DMG)
    {
        HP -= DMG;
    }

    public void LinkUi() => Utils.SetPlayerMarcineOnUI().ForEach(x => x.Initialize(this));
    public void RegisterObserver(IObserver observer) => observers.Add(observer); public void UnregisterObserver(IObserver observer) => observers.Remove(observer);
    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.UpdateObserver();
        }
    }
    public void ChangePlayerState(CharacterState newState)
    {
        currentBState?.Exit();
        currentBState = newState;
        currentBState.Enter();
    }
    public void SetDir(Vector2 vector2) => currentDir = vector2;
    public void SetAttackAngle(Vector2 vector2) => AttackAngle = vector2;

    public void SetAnimatorValue<T>(T type, object value) where T : Enum { characterAnimator.SetAnimatorValue(type, value); }
    public TResult GetAnimatorValue<T, TResult>(T type) where T : Enum { return characterAnimator.GetAnimatorValue<T, TResult>(type); }
    public Type GetCharacterStateType() => currentBState.GetType();


}
