using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyAI : BaseAIEntity
{
    public NavMeshAgent agent;
    public Transform[] wayPoints;
    public Transform player;
    public bool inSight;
    int WaypointIndex;
    public float aiticks;
    public Vector3 target;
    public GameManager manager;

    [SerializeField] private StateMachine<EnemyAI> stateMachine;
    public StateMachine<EnemyAI> StateMachine { get { return StateMachine; } }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        StateMachine.SetOwner(this);
    }
    void Start()
    {
        UpdateDestination();
        StateMachine.ChangeState(AIStates.Patroling);
    }

    public override IEnumerator Tick()
    {
        for (; ; )
        {
            if (!inSight)
            {
                StateMachine.RevertState();
                StateMachine.Update();
                yield return new WaitForSeconds(aiticks);
            }
            
        }
    }

    public void UpdateDestination()
    {
        target = wayPoints[WaypointIndex].position;
        agent.SetDestination(target);
    }

    public void IterateWayPointIndex()
    {
        WaypointIndex++;
        if(WaypointIndex == wayPoints.Length)
        {
            WaypointIndex = 0;
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.GameOver();
        }
    }

    public void Announce(string message, string color = "white")
    {
        print($"<color={color}>Chomper {ID}: {message}</color>");
    }
}
