using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> listAnimal;
    public static int lives = 3;
    public static int score = 0;
    private List<Vector3> listLine;
    public int numberOfAnimal=10;
    public static bool isGameActive = false;
    public static SpawnManager instance;
    public TextMeshProUGUI gameOverText;
    private float gameOverTime = 3.0f;
    private float minSpawnInterval = 1.5f;
    private float maxSpawnInterval = 2.5f;
    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        lives = 3;
        score = 0;
    }

    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnAnimal(new Vector3(-9, 0, 0)));
        StartCoroutine(SpawnAnimal(new Vector3(-9, 0, -13)));
        StartCoroutine(SpawnAnimal(new Vector3(-9, 0, -25)));
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        StartCoroutine(ToEndScreen());
    }

    public void AddScore(int animalScore)
    {
        score += animalScore;
        UIHandler.instance.UpdateScore();
    }

    IEnumerator SpawnAnimal(Vector3 position)
    {
        float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
        while (isGameActive)
        {
              yield return new WaitForSeconds(randomInterval);
              int animalIndex = Random.Range(0, listAnimal.Count);
              GameObject animal = listAnimal[animalIndex];
              Instantiate(animal, position, animal.transform.rotation);
        }
    }

    IEnumerator ToEndScreen()
    {
        yield return new WaitForSeconds(gameOverTime);
        SceneManager.LoadScene(2);
    }

}
