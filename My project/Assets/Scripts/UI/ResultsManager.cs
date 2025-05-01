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

        // Guardar el nuevo high score si cambi�
        if (scoreData.currentScore > PlayerPrefs.GetInt(HighScoreKey, 0))
        {
            PlayerPrefs.SetInt(HighScoreKey, scoreData.highScore);
            PlayerPrefs.Save();
        }

        // Mostrar ambos puntajes
        finalScoreTxt.text = "Your Score: " + scoreData.currentScore.ToString();
        highScoreTxt.text = "High Score: " + scoreData.highScore.ToString();

        // Enviar notificaciones
        var notificationManager = FindObjectOfType<NotificationManager>();
        if (notificationManager != null)
        {
            if (scoreData.currentScore >= scoreData.highScore)
            {
                // Notificaci�n 2: Nuevo Puntaje M�ximo
                notificationManager.SendNotification(
                    "Nuevo Puntaje M�ximo",
                    $"�Felicidades! Has conseguido {scoreData.currentScore} puntos.",
                    5,
                    "icon_1",
                    "icon_1"
                );
            }
            else
            {
                // Notificaci�n 1: Ronda Terminada
                notificationManager.SendNotification(
                    "Ronda Terminada",
                    $"Has conseguido {scoreData.currentScore} puntos.",
                    5,
                    "icon_0",
                    "icon_0"
                );
            }
        }
    }
}
