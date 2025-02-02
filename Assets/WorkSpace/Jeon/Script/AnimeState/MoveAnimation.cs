﻿using UnityEngine;

public class MoveAnimation : StateMachineBehaviour
{
    private CharacterMarcine character;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character ??= animator.GetComponent<CharacterMarcine>();
        character.ChangePlayerState(new MoveState(character));
    }
}
public class MoveState : CharacterState
{
    public MoveState(CharacterMarcine character) : base(character) { }
    public override void Execute()
    {
        character.Move();
    }
    public override void Exit()
    {
        base.Exit();
        character.Rigidbody2D.velocity = Vector2.zero;
    }
}