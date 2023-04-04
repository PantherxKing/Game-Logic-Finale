using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Astate<T> : ScriptableObject
{
    public AIStates StateType;
    public abstract void OnEnter(T entity);
    public abstract void OnExecute(T entity);
    public abstract void OnExit(T entity);
}
