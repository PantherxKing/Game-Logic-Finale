using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RunningState : Astate<CrewMate>
{
    public override void OnEnter(CrewMate entity)
    {
        entity.Run();
    }

    public override void OnExecute(CrewMate entity)
    {
        if (entity.insight == false)
        {
            entity.ChangeState(AIStates.Tasks);
        }
    }

    public override void OnExit(CrewMate entity)
    {
        throw new System.NotImplementedException();
    }
}
