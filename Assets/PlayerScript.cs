using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float movementSpeed = 3f;
    public Rigidbody2D rigidBody;
    Vector2 move;

    public int health = 3;
    public float InvulnTime = 1.5f;
    private bool Invulnerable = false;

    [SerializeField]
    GameObject livesIcons;
    [SerializeField]
    GameObject GameOver;

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
        if (Invulnerable == true)
        {
            SetInvuln();
        }
    }

    void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + move * movementSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "obstacle") && Invulnerable == false)
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        //destroys a life icon 
        Destroy(livesIcons.transform.GetChild(0).gameObject);
        Invulnerable = true;

        if (health == 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
            GameOver.SetActive(true);


        }
    }
    
    public void SetInvuln()
    {
        if (InvulnTime >= 0)
        {
            InvulnTime -= Time.deltaTime;
            //if (//this.gameObject.GetComponent<BoxCollider2D>().enabled == true) {
                //this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            //}
        } 
        else {
            InvulnTime = 1.5f;
            Invulnerable = false;
            //this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        
    }
   
}
