using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChasingState : Astate<EnemyAI>
{
    public override void OnEnter(EnemyAI entity)
    {
        entity.chasePlayer();
    }

    public override void OnExecute(EnemyAI entity)
    {
        if (entity.inSight == false)
        {
            entity.ChangeState(AIStates.Patroling);
        }
    }

    public override void OnExit(EnemyAI entity)
    {
        entity.Announce();
    }

}
