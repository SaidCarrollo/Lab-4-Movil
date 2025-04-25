using UnityEngine;
using TMPro;

public class ResultsManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreTxt;
    [SerializeField] TextMeshProUGUI highScoreTxt;
    [SerializeField] Score_LifeDataSO scoreData;
    [SerializeField] private PaletteSO paletteColor;

    private const string HighScoreKey = "HighScore"; // Clave para PlayerPrefs

    private void Start()
    {
        // Aplicar color de la paleta
        finalScoreTxt.color = paletteColor.color;
        highScoreTxt.color = paletteColor.color;

        // Cargar high score desde PlayerPrefs
        scoreData.highScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        // Verificar y actualizar high score
        scoreData.CheckAndSetHighScore();

        // Guardar el nuevo high score si cambió
        if (scoreData.currentScore > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, scoreData.highScore);
            PlayerPrefs.Save();
        }

        // Mostrar ambos puntajes
        finalScoreTxt.text = "Your Score: " + scoreData.currentScore.ToString();
        highScoreTxt.text = "High Score: " + scoreData.highScore.ToString();
    }
}