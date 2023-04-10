using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TaskState : AState<CrewMate>
{
    public override void OnEnter(CrewMate entity)
    {
        entity.agent.SetDestination(entity.Task.transform.position);
    }

    public override void OnExecute(CrewMate entity)
    {
        if (entity.insight)
        {
            entity.StateMachine.ChangeState(AIStates.Running);
        }
        else
        {
            entity.agent.SetDestination(entity.Task.transform.position);
        }
    }

    public override void OnExit(CrewMate entity)
    {
        entity.Announce("Time to do the Tasks", "Yellow");
    }
}
