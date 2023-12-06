using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Script : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    float range;
    [SerializeField]
    float maxDistance;

    Vector2 wayPoint;

    public int health = 1;

    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private GameObject PowerUp;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        SetNewDestination();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed - Time.deltaTime);

        if(Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }

        if (health <= 0)
        {
            gameManager.enemiesKilled++;
            ChanceOfSpawningPowerUp(0.1f); //10% of dropping a powerup 
            Destroy(this.gameObject);
        }
    }

    private void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance/3 +1f, maxDistance/3 +1f));
    }

    private void ChanceOfSpawningPowerUp(float chance)
    {
        float randomValue = Random.value; // Random value between 0 and 1

        if (randomValue <= chance)
        {
            Instantiate(PowerUp, this.transform.position, Quaternion.identity);
        }
    }
}

