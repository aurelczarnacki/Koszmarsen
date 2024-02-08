using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    #region Singleton
    public static PlayerHp Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    public int hp = 3;
    public GameObject woundedLight;
    public GameObject wounded;
    public bool isUnkillable = false;
    public Material playerMaterial;
    public EventInstance hearbeat;

    private void Start()
    {
        hearbeat = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.heartbeat);
        woundedLight.SetActive(false);
        wounded.SetActive(false);
    }

    public void TakeDamage()
    {
        if (!isUnkillable)
        {
            if (hp > 0)
            {
                hp -= 1;
            }
            CheckWounds();
        }
    }
    public void SetPlayerToUnkillableCoroutine(float duration)
    {
        StartCoroutine(SetPlayerToUnkillable(duration));
    }
    private IEnumerator SetPlayerToUnkillable(float duration)
    {
        isUnkillable = true;
        Color materialColor = playerMaterial.color;
        materialColor.a = 0.1f;
        playerMaterial.color = materialColor;

        yield return new WaitForSeconds(duration);

        materialColor.a = 1f;
        playerMaterial.color = materialColor;
        isUnkillable = false;
    }

    public void Heal()
    {
        if (hp < 3)
        {
            AudioManager.Instance.PlayOneShot(FMODEvents.Instance.heal, transform.position);
            hp += 1;
        }     
        CheckWounds();

    }

    private void CheckWounds()
    {
        switch (hp)
        {
            case 0:
                hearbeat.stop(STOP_MODE.IMMEDIATE);
                SceneManager.LoadScene(3);
                break;
            case 1:
                hearbeat.setPitch(1.5f);
                woundedLight.SetActive(false);
                wounded.SetActive(true);
                break;
            case 2:
                hearbeat.start();
                hearbeat.setPitch(1f);
                wounded.SetActive(false);
                woundedLight.SetActive(true);
                break;
            case 3:
                hearbeat.stop(STOP_MODE.ALLOWFADEOUT);
                wounded.SetActive(false);
                woundedLight.SetActive(false);
                break;

                
        }
    }
}
