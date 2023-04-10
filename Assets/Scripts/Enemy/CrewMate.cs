using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class CrewMate : BaseAIEntity
{
    public NavMeshAgent agent;

    public Transform Guard;

    public Transform Task;

    public LayerMask isground, isplayer;

    public float sightRange;
    public bool insight;

    public float aiticks;

    public GameManager manager;

    [SerializeField] private StateMachine<CrewMate> stateMachine;

    public StateMachine<CrewMate> StateMachine { get { return StateMachine; } }

    private void Awake()
    {
        ID = sNextValidID;
    }

    private void Start()
    {
        StateMachine.ChangeState(AIStates.Tasks);
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        insight = Physics.CheckSphere(transform.position, sightRange, isplayer);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Task")
        {
            StartCoroutine(TaskStarted());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Task")
        {
            StopCoroutine(TaskStarted());
        }
    }

    private IEnumerator TaskStarted()
    {
        yield return new WaitForSeconds(20f);
        manager.tasksLeft--;
    }

    public void Announce(string message, string color = "white")
    {
        print($"<color={color}>CrewMate {ID}: {message}</color>");
    }

    public override IEnumerator Tick()
    {
        for (; ; )
        {
            if (!insight)
            {
                StateMachine.RevertState();
                StateMachine.Update();
                yield return new WaitForSeconds(aiticks);
            }

        }
    }
}
