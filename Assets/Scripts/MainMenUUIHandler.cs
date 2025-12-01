using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenUUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(3);
    }

}
