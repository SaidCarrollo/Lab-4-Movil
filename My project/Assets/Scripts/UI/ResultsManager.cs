using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalscoretxt;
    [SerializeField] Score_LifeDataSO finalscore;
    [SerializeField] private PaletteSO paletteColor;

    private void Start()
    {
        finalscoretxt.color = paletteColor.color;

        finalscore.CheckAndSetHighScore(); // Actualiza si el score actual supera al anterior

        finalscoretxt.text = "High Score: " + finalscore.highScore;
    }
}
