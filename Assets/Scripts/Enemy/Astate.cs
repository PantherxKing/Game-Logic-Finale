using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AState<T> : ScriptableObject
{
    public AIStates stateType;
    public abstract void OnEnter(T entity);
    public abstract void OnExecute(T entity);
    public abstract void OnExit(T entity);
}
