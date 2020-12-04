using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, tilt;
    public float xMin, xMax;
    public GameObject explosion;

    Rigidbody rigidBody;
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
        rigidBody = GetComponent<Rigidbody>();
        speed = PlayerPrefs.GetFloat("playerSpeed", speed);
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Vertical");
        rigidBody.velocity = new Vector3(-speed * moveHorizontal, 0.0f, 0.0f);
        rigidBody.position = new Vector3(
            Mathf.Clamp(rigidBody.position.x, xMin, xMax),
            0.0f,
            0.0f
        );
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;
        if (other.tag == "Hazard")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            gameController.GameOver();
        }

    }
}
