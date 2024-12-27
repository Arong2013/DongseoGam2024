using UnityEngine;

public class AttackAnimation : StateMachineBehaviour
{
    private CharacterMarcine character;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        character ??= animator.GetComponent<CharacterMarcine>();
        character.ChangePlayerState(new AttackState(character));
    }
}


public class AttackState : CharacterState
{
    public AttackState(CharacterMarcine character) : base(character) { }

    public override void Enter()
    {
        base.Enter();
        character.Attack();
    }
    public override void Execute()
    {
        character.Move();
    }
}