using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RunningState : AState<CrewMate>
{
    public override void OnEnter(CrewMate entity)
    {
        entity.agent.SetDestination(entity.Guard.transform.position);
    }

    public override void OnExecute(CrewMate entity)
    {
        if (entity.insight == false)
        {
            entity.Tick();
        }
        else
        {
            entity.agent.SetDestination(entity.Guard.transform.position);
        }
    }

    public override void OnExit(CrewMate entity)
    {
        entity.Announce("Safe.", "Blue");
    }
}
