using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;
    public GameObject LoadingScreenObject;
    public Slider ProgressBar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SwitchToScene(string sceneName)
    {
        LoadingScreenObject.SetActive(true);
        ProgressBar.value = 0;
        StartCoroutine(SwitchToSceneAsync(sceneName));
    }

    IEnumerator SwitchToSceneAsync(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            ProgressBar.value = asyncLoad.progress;
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);
        LoadingScreenObject.SetActive(false);
    }
}
