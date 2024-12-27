using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "ActionChessTarget", menuName = "Behavior/Actions/ChessTarget")]
public class ActionChessTargetSO : BehaviorActionSO
{
    [SerializeField] float stopDistance = 4.0f; // 멈출 거리

    public override BehaviorAction CreateAction()
    {
        return new ActionChessTarget(stopDistance);
    }
}

public class ActionChessTarget : BehaviorAction
{
    float stopDistance;

    public ActionChessTarget(float stopDistance)
    {
        this.stopDistance = stopDistance;
        
    }
    public override BehaviorState Execute()
    {
        var dis = character.transform.position - GameManager.Instance.playerMarcine.transform.position;
        if (dis.magnitude <= stopDistance)
        {
            return BehaviorState.SUCCESS;
        }
        else
        {
            character.SetDir(dis);
            character.Move();
            return BehaviorState.RUNNING;
        }
    }
}
