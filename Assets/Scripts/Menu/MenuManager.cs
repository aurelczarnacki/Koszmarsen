using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject buttons;
    public GameObject leaderboard;
    public GameObject credits;
    public Camera cam;
    public float moveSpeed = 5f;
    public GameObject currentlyActive;
    public float cameraMoveDistance;
    private Vector3 initialCameraPosition;
    public EventInstance mainMusic;

    #region Singleton
    public static MenuManager instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }
    #endregion


    public void Start()
    {
        currentlyActive = buttons;
        initialCameraPosition = cam.transform.position;
        mainMusic = AudioManager.Instance.CreateEventInstance(FMODEvents.Instance.mainMusic);
    }

    private void Update()
    {
        UpdateSound();
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene(2);
    }

    public void OnLeaderboardClick()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.slide, this.transform.position);
        StartCoroutine(MoveCameraRight());
    }

    public void OnCreditsClick()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.slide, this.transform.position);
        StartCoroutine(MoveCameraUp());

    }

    public void OnBackClick()
    {
        AudioManager.Instance.PlayOneShot(FMODEvents.Instance.slide, this.transform.position);
        StartCoroutine(MoveCameraBack());
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

    public IEnumerator MoveCameraUp()
    {
        currentlyActive.SetActive(false);
        Vector3 targetPosition = cam.transform.position + Vector3.up * cameraMoveDistance;
        while (Vector3.Distance(cam.transform.position, targetPosition) > 1f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * moveSpeed);
            yield return null;
        }
        credits.SetActive(true);
        currentlyActive = credits;
    }

    public IEnumerator MoveCameraRight()
    {
        currentlyActive.SetActive(false);
        Vector3 targetPosition = cam.transform.position + Vector3.right * cameraMoveDistance;
        while (Vector3.Distance(cam.transform.position, targetPosition) > 1f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * moveSpeed);

            yield return null;
        }
        leaderboard.SetActive(true);
        currentlyActive = leaderboard;

    }

    public IEnumerator MoveCameraBack()
    {
        currentlyActive.SetActive(false);
        Vector3 targetPosition = initialCameraPosition;
        while (Vector3.Distance(cam.transform.position, targetPosition) > 1f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetPosition, Time.deltaTime * moveSpeed);

            yield return null;
        }
        buttons.SetActive(true);
        currentlyActive = buttons;

    }

    private void UpdateSound()
    {
        PLAYBACK_STATE playbackState;
        mainMusic.getPlaybackState(out playbackState);
        if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            mainMusic.start();
        }
    }
}
