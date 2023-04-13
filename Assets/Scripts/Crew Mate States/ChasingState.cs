using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ChasingState : AState<EnemyAI>
{
    public override void OnEnter(EnemyAI entity)
    {
        entity.agent.SetDestination(entity.player.position);
    }

    public override void OnExecute(EnemyAI entity)
    {
        if (entity.inSight == false)
        {
            entity.StateMachine.RevertState();
        }
        else
        {
            entity.agent.SetDestination(entity.player.position);
        }
    }

    public override void OnExit(EnemyAI entity)
    {
        entity.Announce("Dam Lost Him.", "blue");
    }

}
