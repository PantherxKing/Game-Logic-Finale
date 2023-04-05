using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameManager manager;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CrewMate")
        {
            Destroy(other.gameObject);
            manager.CrewMatesLeft--;
        }
    }
}
