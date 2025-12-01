using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUIHandler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI finalScoreValue;
    private void Start()
    {
        finalScoreValue.text = SpawnManager.score.ToString();
    }
    public void RestartGame()
    {
        Destroy(SpawnManager.instance.gameObject);
        SceneManager.LoadScene(0);
    }

}
