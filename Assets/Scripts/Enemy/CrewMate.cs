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

    public GameObject vfx;

    public GameManager manager;

    [SerializeField] private StateMachine<CrewMate> stateMachine;

    public StateMachine<CrewMate> StateMachine { get { return stateMachine; } }

    private void Awake()
    {
        ID = sNextValidID;
        StateMachine.SetOwner(this);
    }

    private void Start()
    {
        StateMachine.ChangeState(AIStates.Tasks);
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Tick());
        vfx.SetActive(false);
    }

    private void Update()
    {
        insight = Physics.CheckSphere(transform.position, sightRange, isplayer);
    }

    public void Announce(string message, string color = "white")
    {
        print($"<color={color}>CrewMate {ID}: {message}</color>");
    }

    public override IEnumerator Tick()
    {
        for (; ; )
        {
            StateMachine.Update();
            yield return new WaitForSeconds(aiticks);
        }
    }
}
