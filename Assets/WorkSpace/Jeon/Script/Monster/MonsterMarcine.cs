using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMarcine : CharacterMarcine
{
    [SerializeField] List<BehaviorSequenceSO> behaviorSequencesSO;
    List<BehaviorSequence> behaviorSequences = new List<BehaviorSequence>();

    public override void Attack()
    {
        
    }

    public override void Start()
    {
        base.Start();
        behaviorSequencesSO.ForEach(sequence => behaviorSequences.Add(sequence.CreatBehaviorSequence(this)));
        
        currentBState = new IdleState(this,animator);
    }

    public override void TakeDamage(float DMG)
    {
        animator.SetTrigger("SetDamage");
        HP -= DMG;
        if (HP < 0)
            animator.SetTrigger("Dead");
    }

    private void Update()
    {
        Walkable = true;
        for (var i = 0; i < behaviorSequences.Count; i++)
        {
            var seq = behaviorSequences[i];
            if (seq.Execute() == BehaviorState.FAILURE)
                continue;
            else
                break;
        }
    }

    public void MonsterDeadEvent()
    {
        gameObject.SetActive(false);
    }
}
