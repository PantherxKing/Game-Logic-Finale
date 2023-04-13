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
            other.gameObject.GetComponent<CrewMate>().vfx.SetActive(true);
            StartCoroutine(TaskStarted());
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CrewMate")
        {
            other.gameObject.GetComponent<CrewMate>().vfx.SetActive(false);
            StopCoroutine(TaskStarted());
        }
    }

    private IEnumerator TaskStarted()
    {
        yield return new WaitForSeconds(20f);
        manager.tasksLeft--;
    }
}
