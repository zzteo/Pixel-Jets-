using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 3f;
    public Rigidbody2D rigidBody;
    Vector2 move;

    public int health = 3;

    [SerializeField]
    GameObject livesIcons;

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
            TakeDamage();
        }
        if (collision.gameObject.tag == "obstacle")
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        //destroys a life icon 
        Destroy(livesIcons.transform.GetChild(0).gameObject);

        if (health == 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
    
   
}
