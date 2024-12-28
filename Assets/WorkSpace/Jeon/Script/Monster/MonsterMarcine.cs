using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMarcine : CharacterMarcine
{
    [SerializeField] List<BehaviorSequenceSO> behaviorSequencesSO;
    List<BehaviorSequence> behaviorSequences = new List<BehaviorSequence>();
    [SerializeField] bool Pupple_Rain;

    public override void Attack()
    {

    }

    public override void Start()
    {
        base.Start();
        behaviorSequencesSO.ForEach(sequence => behaviorSequences.Add(sequence.CreatBehaviorSequence(this)));

        currentBState = new IdleState(this, animator);
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
        if (Pupple_Rain)
        {
            TakeDamage(-0.3f);
        }
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


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerMarcine>(out PlayerMarcine marcine))
        {
            marcine.TakeDamage(1);
        }
    }

    public void MonsterDeadEvent()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        if(Pupple_Rain)
        {
            CutScenemanager.Instance.PlayCutScene(100);
        }
    }
}
