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
        behaviorSequencesSO.ForEach(sequence => behaviorSequences.Add(sequence.CreatBehaviorSequence(this)));
        Walkable = true;
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
