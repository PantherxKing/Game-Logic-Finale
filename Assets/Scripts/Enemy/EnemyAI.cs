using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] wayPoints;
    public Transform player;
    public bool inSight;
    int WaypointIndex;
    Vector3 target;

    public List<Astate<EnemyAI>> stateMachine = new List<Astate<EnemyAI>>();
    public Astate<EnemyAI> currentState;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        UpdateDestination();
        ChangeState(AIStates.Patroling);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < 1)
        {
            IterateWayPointIndex();
            UpdateDestination();
        }
        if (inSight)
        {
            ChangeState(AIStates.Chasing);
        }
    }

    public void UpdateDestination()
    {
        target = wayPoints[WaypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWayPointIndex()
    {
        WaypointIndex++;
        if(WaypointIndex == wayPoints.Length)
        {
            WaypointIndex = 0;
        }
    }

    public void chasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    public void ChangeState(AIStates thisState)
    {
        Astate<EnemyAI> newState = stateMachine.Find(s => s.StateType == thisState);
        Assert.IsNotNull(newState, "EnemyAI::ChangeState:: newState is null");

        StartCoroutine(Transition(newState));
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }

    private IEnumerator Transition(Astate<EnemyAI> state)
    {
        yield return new WaitForEndOfFrame();
        currentState?.OnExit(this);
        currentState = state;
        currentState.OnEnter(this);
    }

    public void Announce()
    {
        print("over");
    }
}
