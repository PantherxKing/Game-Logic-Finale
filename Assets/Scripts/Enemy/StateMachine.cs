using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[Serializable]
public class StateMachine<T>
{
    [SerializeField] private List<AState<T>> states;
    private T owner;

    private AState<T> CurrentState { get; set; }
    private AState<T> GlobalState { get; set; }
    private AIStates PreviousStateType { get; set; }

    public void SetOwner(T owner)
    {
        this.owner = owner;
    }

    public void ChangeState(AIStates stateType)
    {
        AState<T> newState = states.Find(state => state.stateType == stateType);
        Assert.IsNotNull(newState, "StateMachine.ChangeState: newState is null.");

        if (CurrentState)
        {
            PreviousStateType = CurrentState.stateType;
            CurrentState.OnExit(owner);
        }
        CurrentState = newState;
        CurrentState.OnEnter(owner);
    }

    public void RevertState()
    {
        ChangeState(PreviousStateType);
    }

    public bool IsInState(AIStates stateType)
    {
        return CurrentState.stateType == stateType;
    }

    public void Update()
    {
        if (GlobalState) GlobalState.OnExecute(owner);
        if (CurrentState) CurrentState.OnExecute(owner);
    }

    public bool HandleMessage()
    {
        throw new NotImplementedException();
    }
}
