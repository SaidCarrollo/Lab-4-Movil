using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System;

public class SceneGlobalManager : MonoBehaviour
{
    public static SceneGlobalManager Instance { get; private set; }
    public SceneLoader SceneLoader { get; private set; }

    public static Action<string> OnLoadGameWithResults;
    public static Action OnShowResults;
    public static Action OnUnloadGameAndResults;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            SceneLoader = GetComponent<SceneLoader>();
            DontDestroyOnLoad(gameObject);

            OnLoadGameWithResults += SceneLoader.LoadGameWithResults;
            OnShowResults += SceneLoader.ShowResults;
            OnUnloadGameAndResults += SceneLoader.UnloadGameAndResults;

           // SceneManager.LoadScene("MenuStart");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        OnLoadGameWithResults -= SceneLoader.LoadGameWithResults;
        OnShowResults -= SceneLoader.ShowResults;
        OnUnloadGameAndResults -= SceneLoader.UnloadGameAndResults;
    }
}

