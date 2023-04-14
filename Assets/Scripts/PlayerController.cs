using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image imageCooldown;
    public GameObject weapon;
    NavMeshAgent agent;
    public AssetBundleLoader AssetBundleLoader;

    bool isCooldown = false;
    public float coolDownTimer = 5f;
    public KeyCode Attack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        imageCooldown.fillAmount = 0f;
        weapon.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }

        kill();
    }

    public void kill()
    {
        if (Input.GetKey(Attack) && !isCooldown)
        {
            isCooldown = true;
            imageCooldown.fillAmount = 1;
            StartCoroutine(damage());
        }
        if (isCooldown)
        {
            imageCooldown.fillAmount -= 1 / coolDownTimer * Time.deltaTime;

            if(imageCooldown.fillAmount <= 0)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    IEnumerator damage()
    {
        weapon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        weapon.SetActive(false);
    }
}
