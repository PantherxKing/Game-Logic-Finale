using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardSight : MonoBehaviour
{
    public EnemyAI EA;

    private void Start()
    {
        EA = GetComponentInParent<EnemyAI>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EA.inSight = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            EA.inSight = false;
        }
    }

}
