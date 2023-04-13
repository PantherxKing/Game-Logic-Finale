using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RunningState : AState<CrewMate>
{
    public override void OnEnter(CrewMate entity)
    {
        entity.agent.SetDestination(entity.Guard.position);
    }

    public override void OnExecute(CrewMate entity)
    {
        if (entity.insight == false)
        {
            entity.StateMachine.RevertState();
        }
        else
        {
            entity.agent.SetDestination(entity.Guard.position);
        }
    }

    public override void OnExit(CrewMate entity)
    {
        entity.Announce("Safe.", "Blue");
    }
}
