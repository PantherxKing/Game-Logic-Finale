using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public abstract class BaseAIEntity : MonoBehaviour
{
    private int id;
    protected static int sNextValidID = 0;

    public int ID
    {
        get { return id; }
        set
        {
            Assert.IsTrue(value >= sNextValidID);
            id = value;
            sNextValidID += id + 1;
        }
    }
}