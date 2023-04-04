using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PatrolingState : Astate<EnemyAI>
{
    public override void OnEnter(EnemyAI entity)
    {
        entity.UpdateDestination(); 
    }

    public override void OnExecute(EnemyAI entity)
    {
        if (entity.inSight)
        {
            entity.ChangeState(AIStates.Chasing);
        }
    }

    public override void OnExit(EnemyAI entity)
    {
        entity.Announce();
    }
}
