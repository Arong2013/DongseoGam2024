using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMarcine : CharacterMarcine
{
    [SerializeField] List<BehaviorSequenceSO> behaviorSequencesSO;
    List<BehaviorSequence> behaviorSequences = new List<BehaviorSequence>();

    public override void Start()
    {
        base.Start();
        Debug.Log("¾Æ¾Æ");
        behaviorSequencesSO.ForEach(sequence => behaviorSequences.Add(sequence.CreatBehaviorSequence(this)));
        Walkable = true;
        currentBState = new IdleState(this,animator);
    }

    private void Update()
    {
        for (var i = 0; i < behaviorSequences.Count; i++)
        {
            var seq = behaviorSequences[i];
            if (seq.Execute() == BehaviorState.FAILURE)
                continue;
            else
                break;
        }
    }
}
