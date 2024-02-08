using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public float transitionTime = 3f;
    public Slider progressSlider;

    private float elapsedTime = 0f;

    void Update()
    {
        if (elapsedTime < transitionTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / transitionTime);
            progressSlider.value = progress;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
