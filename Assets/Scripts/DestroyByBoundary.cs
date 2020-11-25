using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    public int scoreValue;
    GameController gameController;
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot find `GameController` script.");
        }
    }
    void OnTriggerExit(Collider other) 
    {
        Destroy(other.gameObject);
        gameController.AddScore(scoreValue);
    }
}
