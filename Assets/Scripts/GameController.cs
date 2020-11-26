using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard;

    public Vector3 spawnValues;
    public float startWait, spawnWait;
    public Text scoreText;
    int score;
    bool isAlive;
    void Start()
    {
        isAlive = true;
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(isAlive)
        { 
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnValues.x, spawnValues.x),
                spawnValues.y,
                spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(spawnWait);   
        }
    }

    public void AddScore(int newScoreValue)
    {
        if (!isAlive) return;
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Pontuação: " + score.ToString();
    }

    public void GameOver()
    {
        isAlive = false;
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu 3D", LoadSceneMode.Single);
    }
}
