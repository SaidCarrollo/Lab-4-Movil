using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    [SerializeField]SelectedShipDataSO Slship;
    public void MenuStart()
    {
        SceneManager.LoadScene("SelectionC");
    }
    public void Selectionmenu()
    {
        Time.timeScale = 1f;
        SceneGlobalManager.OnUnloadGameAndResults?.Invoke();
        SceneManager.LoadScene("SelectionC");
    }
    public void AcelerometerScene()
    {
        if (Slship != null)
        {
            SceneGlobalManager.OnLoadGameWithResults?.Invoke("AcelerometerScene");
        }
    }
    public void GyroscopeScene()
    {
        if(Slship != null)
            SceneManager.LoadScene("GyroscopeScene");
    }
}
