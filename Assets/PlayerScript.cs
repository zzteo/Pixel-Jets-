using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 3f;
    public Rigidbody2D rigidBody;
    Vector2 move;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + move * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerKilled();
        }
        if (collision.gameObject.tag == "obstacle")
        {
            playerKilled();
        }

    }

    private void playerKilled()
    {
        Time.timeScale = 0;
    }
}
