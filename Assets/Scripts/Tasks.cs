using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{
    public GameManager manager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CrewMate")
        {
            StartCoroutine(TaskStarted());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CrewMate")
        {
            StopCoroutine(TaskStarted());
        }
    }

    private IEnumerator TaskStarted()
    {
        yield return new WaitForSeconds(20f);
        manager.tasksLeft--;
    }
}
