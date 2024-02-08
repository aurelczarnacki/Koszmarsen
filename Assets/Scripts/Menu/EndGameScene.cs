using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameScene : MonoBehaviour
{
    public TextMeshProUGUI pointsText;

    void Start()
    {
        pointsText.text = "Points: " + Points.Instance.points.ToString();
    }

    public void onMainMenuClick()
    {
        MenuManager.instance.mainMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SceneManager.LoadScene(0);
    }
}
