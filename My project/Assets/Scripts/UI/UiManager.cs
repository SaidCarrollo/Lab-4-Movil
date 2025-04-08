using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{
    [SerializeField]SelectedShipDataSO Slship;
    public void MenuStart()
    {
        SceneManager.LoadScene("MenuStart");
    }
    public void Selectionmenu()
    {
        SceneManager.LoadScene("SelectionC");
    }
    public void AcelerometerScene()
    {
        if (Slship != null)
            SceneManager.LoadScene("AcelerometerScene");
    }
    public void GyroscopeScene()
    {
        if(Slship != null)
            SceneManager.LoadScene("GyroscopeScene");
    }
}
