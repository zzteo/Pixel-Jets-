using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    [SerializeField]
    private Sprite[] powerUpIcon;

    [SerializeField]
    private float fallingDownSpeed;

    private int powerUp;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        System.Action[] functions = { PowerUp1, PowerUp2, PowerUp3};

        // Randomly pick a function from the array
        int randomIndex = Random.Range(0, functions.Length);
        System.Action randomFunction = functions[randomIndex];

        // Call the randomly selected function
        randomFunction();
    }

    private void Update()
    {
        //moving down
        transform.Translate(Vector2.down * fallingDownSpeed * Time.deltaTime);
    }

    //sets the power up icon and the powerUp variable accordingly with the power up dropped 
    private void PowerUp1()
    {
        Debug.Log("powerUp 1");
        powerUp = 1;
        spriteRenderer.sprite = powerUpIcon[0];
    }

    private void PowerUp2()
    {
        Debug.Log("powerUp 2");
        powerUp = 2;
        spriteRenderer.sprite = powerUpIcon[1];
    }

    private void PowerUp3()
    {
        Debug.Log("powerUp 3");
        powerUp = 3;
        spriteRenderer.sprite = powerUpIcon[2];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            switch (powerUp)
            {
                //when colliding with the player, it accesses the shooting script and it changes the powerUp variable which will tell the shooting script how to behave 
                case 1:
                    Debug.Log("powerUp1 active");
                    collision.gameObject.GetComponent<ProjectileShootScript>().powerUp = 1;
                    Destroy(this.gameObject);
                    break;

                case 2:
                    Debug.Log("powerUp2 active");
                    collision.gameObject.GetComponent<ProjectileShootScript>().powerUp = 2;
                    Destroy(this.gameObject);
                    break;

                case 3:
                    Debug.Log("powerUp3 active");
                    collision.gameObject.GetComponent<ProjectileShootScript>().powerUp = 3;
                    Destroy(this.gameObject);
                    break;
            }
        }
    }
}
