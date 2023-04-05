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
    public TextMeshProUGUI textCooldown;
    public GameObject weapon;
    NavMeshAgent agent;

    bool isCooldown = false;
    float coolDownTimer = 10f;
    float cooldownTime = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        textCooldown.gameObject.SetActive(false);
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

        if(isCooldown)
        {
            Cooldown();
        }
    }

    void Cooldown()
    {
        coolDownTimer -= Time.deltaTime;

        if (coolDownTimer <= 0f)
        {
            isCooldown = false;
            textCooldown.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0f;
        }
        else
        {
            textCooldown.text = Mathf.RoundToInt(coolDownTimer).ToString();
            imageCooldown.fillAmount = coolDownTimer / cooldownTime;
        }
    }

    public void kill()
    {
        if (!isCooldown)
        {
            isCooldown = true;
            textCooldown.gameObject.SetActive(true);
            coolDownTimer = cooldownTime;
            StartCoroutine(damage());
        }
    }

    IEnumerator damage()
    {
        weapon.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        weapon.SetActive(false);
    }
}
