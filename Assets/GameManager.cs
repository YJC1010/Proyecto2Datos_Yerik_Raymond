using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float gameTime = 180f;
    public TextMeshProUGUI timerText;

    void Update()
    {
        gameTime -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(gameTime);

        if (gameTime <= 0)
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
            // Aquí puedes comparar los puntos y declarar al ganador
        }
    }
}

