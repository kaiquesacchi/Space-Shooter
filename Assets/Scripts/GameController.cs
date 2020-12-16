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
    AudioSource audioSource;
    bool firstLoop;
    void Start()    
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefs.GetFloat("mainVolume", 0.5f);
        isAlive = true;

        firstLoop = true;


        spawnWait = PlayerPrefs.GetFloat("spawnWait", spawnWait);
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

    void Update()
    {
        if (!firstLoop) return;
        firstLoop = false;
        // Requests.
        EventsManager.instance.GetParametersResponseTrigger += SetCustomParameters;
        string email = PlayerPrefs.GetString("loginEmail", "");
        string password = PlayerPrefs.GetString("loginPassword", "");

        if (email != "" && password != "")
        {
            EventsManager.instance.OnLoginTrigger(gameObject.GetInstanceID(), email, password, false);
            EventsManager.instance.OnGetParametersRequestTrigger(gameObject.GetInstanceID());
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
        EventsManager.instance.GetParametersResponseTrigger -= SetCustomParameters;
        StartCoroutine(OpenMenu());
    }

    IEnumerator OpenMenu()
    {
        yield return new WaitForSeconds(3);
        string email = PlayerPrefs.GetString("loginEmail", "");
        string password = PlayerPrefs.GetString("loginPassword", "");
        if (email != "" && password != "")
        {
            EventsManager.instance.OnUploadImagesTrigger(gameObject.GetInstanceID());
        }
        SceneManager.LoadScene("Menu 3D", LoadSceneMode.Single);
    }

    void SetCustomParameters(int id, CustomParametersResponse response)
    {
        float velocity = response.velocity;
        float difficulty = response.difficulty;
        PlayerPrefs.SetFloat("spawnWait", (float) (5 - (5 - 0.5) * difficulty / 100f));
        PlayerPrefs.SetFloat("playerSpeed", (float) (3 + (10 - 3) * velocity / 100f));
    }
}
