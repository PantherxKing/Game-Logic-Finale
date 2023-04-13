using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameManager manager;
    public ParticleSystem ps;
    public GameObject particle;

    private void Start()
    {
        particle.SetActive(false);
        ps = particle.GetComponent<ParticleSystem>();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CrewMate")
        {
            Destroy(other.gameObject);
            StartCoroutine(playDeath());
            manager.CrewMatesLeft--;
        }
    }

    public IEnumerator playDeath()
    {
        particle.SetActive(true);
        ps.Play();
        yield return new WaitForSeconds(0.2f);
        particle.SetActive(false);
    }
}
