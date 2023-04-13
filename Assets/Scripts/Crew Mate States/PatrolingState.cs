using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CreateAssetMenu]
public class PatrolingState : AState<EnemyAI>
{
    public override void OnEnter(EnemyAI entity)
    {
        if (Vector3.Distance(entity.transform.position, entity.target) < 1)
        {
            entity.IterateWayPointIndex();
            entity.UpdateDestination();
        }
    }

    public override void OnExecute(EnemyAI entity)
    {
        if (entity.inSight)
        {
            entity.StateMachine.ChangeState(AIStates.Chasing);
        }
        else
        {
            if (Vector3.Distance(entity.transform.position, entity.target) < 1)
            {
                entity.IterateWayPointIndex();
                entity.UpdateDestination();
            }
        }
    }

    public override void OnExit(EnemyAI entity)
    {
        entity.Announce("Patrolling.", "Yellow");
    }
}
