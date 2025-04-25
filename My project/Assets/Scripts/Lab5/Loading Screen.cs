using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public string sceneToLoad = "MenuStart";
    public Image progressBar;

    void Start()
    {
        StartCoroutine(LoadSceneAsync());
    }

    IEnumerator LoadSceneAsync()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneToLoad);
        operation.allowSceneActivation = false;

        while (operation.progress < 0.9f)
        {
            progressBar.fillAmount = operation.progress;
            yield return null;
        }

        // Simula una pausa para mostrar el progreso completo
        yield return new WaitForSeconds(1f);
        progressBar.fillAmount = 1f;

        // Activa la escena cargada
        operation.allowSceneActivation = true;
    }
}
