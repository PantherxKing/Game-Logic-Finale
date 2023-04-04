using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public class CrewMate : BaseAIEntity
{
    //public Respawn Spawn;

    public NavMeshAgent agent;

    public Transform Guard;

    public Transform Task;

    public LayerMask isground, isplayer;

    public float sightRange;
    public bool insight;

    public GameManager manager;

    public List<Astate<CrewMate>> stateMachine = new List<Astate<CrewMate>>();
    public Astate<CrewMate> currentState;

    private void Awake()
    {
        ID = sNextValidID;
    }

    private void Start()
    {
        ChangeState(AIStates.Tasks);
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        insight = Physics.CheckSphere(transform.position, sightRange, isplayer);
        if (!insight) ChangeState(AIStates.Tasks);
    }

    public void ChangeState(AIStates thisState)
    {
        Astate<CrewMate> newState = stateMachine.Find(s => s.StateType == thisState);
        Assert.IsNotNull(newState, "CrewMate::ChangeState:: newState is null");

        StartCoroutine(Transition(newState));
    }

    private IEnumerator Transition(Astate<CrewMate> state)
    {
        yield return new WaitForEndOfFrame();
        currentState?.OnExit(this);
        currentState = state;
        currentState.OnEnter(this);
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

    public void MovingToTask()
    {
        agent.SetDestination(Task.transform.position);
    }
    public void Run()
    {
        agent.SetDestination(Guard.transform.position);
    }

    public void Announce(string message, string color = "white")
    {
        print($"<color={color}>CrewMate {ID}: {message}</color>");
    }
}
