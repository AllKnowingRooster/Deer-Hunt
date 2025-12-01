using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public static UIHandler instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance=this;
        scoreText.text = "Score :" + SpawnManager.score.ToString();
        livesText.text = "Lives :" + SpawnManager.lives.ToString();
    }


    public void UpdateScore()
    {
        scoreText.text = "Score :" + SpawnManager.score.ToString();
    }

    public void UpdateLives()
    {
        livesText.text = "Lives :" + SpawnManager.lives.ToString();
    }

}
