using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject OppPrefab;
    public void SpawnPlayer()
    {
        Instantiate(PlayerPrefab, transform.position, Quaternion.identity);
    }

    public void SpawnOppenent()
    {
        Instantiate(OppPrefab, transform.position, Quaternion.identity);
    }
}
