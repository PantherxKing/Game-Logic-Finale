using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TaskState : Astate<CrewMate>
{
    public override void OnEnter(CrewMate entity)
    {
        entity.MovingToTask();
    }

    public override void OnExecute(CrewMate entity)
    {
        if (entity.insight)
        {
            entity.ChangeState(AIStates.Running);
        }
    }

    public override void OnExit(CrewMate entity)
    {
        throw new System.NotImplementedException();
    }
}
