using UnityEngine;

[CreateAssetMenu(fileName = "Score_LifeData", menuName = "ScriptableObjects/ScoreLifeData")]
public class Score_LifeDataSO : ScriptableObject
{
    public int currentScore;
    public int currentlife;
    public int highScore;

    public void ResetScore()
    {
        currentScore = 0;
    }

    public void AddPoints(int amount)
    {
        currentScore += amount;
    }

    public void RestLife(int amount)
    {
        currentlife -= amount;
    }

    public void CheckAndSetHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }

    // Método para cargar el high score desde PlayerPrefs
    public void LoadHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }
}