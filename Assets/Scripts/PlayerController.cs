using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, tilt;
    public float xMin, xMax;

    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
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
}
