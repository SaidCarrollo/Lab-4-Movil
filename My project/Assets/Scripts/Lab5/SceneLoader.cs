using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    private string currentGameScene;
    private const string resultsScene = "Results";
    private bool resultsLoaded = false;

    public void LoadGameWithResults(string gameSceneName)
    {
        StartCoroutine(LoadGameAndResultsAsync(gameSceneName));
    }

    private IEnumerator LoadGameAndResultsAsync(string gameSceneName)
    {
        // 1. Cargar escena Game como principal
        yield return SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Single);
        currentGameScene = gameSceneName;

        // 2. Cargar Results como aditiva
        yield return SceneManager.LoadSceneAsync(resultsScene, LoadSceneMode.Additive);
        resultsLoaded = true;

        // 3. Ocultar Results inicialmente
        HideResultsScene();

        // 4. Establecer Game como escena activa
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(gameSceneName));
    }

    private void HideResultsScene()
    {
        if (resultsLoaded)
        {
            Scene resultsSceneRef = SceneManager.GetSceneByName(resultsScene);
            GameObject[] rootObjects = resultsSceneRef.GetRootGameObjects();
            foreach (GameObject obj in rootObjects)
            {
                obj.SetActive(false);
            }
        }
    }

    public void ShowResults()
    {
        if (!resultsLoaded) return;

        Scene resultsSceneRef = SceneManager.GetSceneByName(resultsScene);
        GameObject[] rootObjects = resultsSceneRef.GetRootGameObjects();

        for (int i = 0; i < rootObjects.Length; i++)
        {
            rootObjects[i].SetActive(true);
        }

        Time.timeScale = 0f;
    }

    public void UnloadGameAndResults()
    {
        StartCoroutine(UnloadGameScenes());
    }

    private IEnumerator UnloadGameScenes()
    {
        if (resultsLoaded)
        {
            yield return SceneManager.UnloadSceneAsync(resultsScene);
            resultsLoaded = false;
        }
    }
}
