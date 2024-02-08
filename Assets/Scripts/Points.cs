using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Points : MonoBehaviour
{
    #region Singleton
    public static Points Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        DontDestroyOnLoad(Instance);
    }
    #endregion

    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI bonusPointsText;
    public int points = 0;
    public float pointsPerSecond = 1;
    public bool isPointsAdding = false;

    private void Start()
    {
        InvokeRepeating("AddPoints", 1.0f, 1.0f);
        InvokeRepeating("IncreasePointsPerSecond", 5f, 5f);
    }
    public void ChangePlayerPointsSpeedCoroutine(int pointsMultiplier, float duration)
    {
        StartCoroutine(ChangePlayerPointsSpeed(pointsMultiplier, duration));
    }
    private IEnumerator ChangePlayerPointsSpeed(int pointsMultiplier, float duration)
    {
        pointsPerSecond *= pointsMultiplier;
        bonusPointsText.gameObject.SetActive(true);

        yield return new WaitForSeconds(duration);

        pointsPerSecond /= pointsMultiplier;
        bonusPointsText.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (isPointsAdding)
        {
            StartCoroutine(AddSinglePoints());
            isPointsAdding = false;
        }
    }

    IEnumerator AddSinglePoints()
    {
        for (int i = 0; i < pointsPerSecond; i++)
        {
            points += 1;
            pointsText.text = points.ToString("D5");
            float secondsToWait = 1 / pointsPerSecond;
            yield return new WaitForSeconds(secondsToWait);
        }
    }

    void AddPoints()
    {
        if(PlayerHp.Instance.hp < 1)
        {
            CancelInvoke("AddPoints");
        }
        isPointsAdding = true;       
    }

    void IncreasePointsPerSecond()
    {
        pointsPerSecond += 1;
    }
}
