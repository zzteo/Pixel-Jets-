using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private float minSpeed = 0.5f;
    [SerializeField]
    private float maxSpeed = 0.75f;

    [SerializeField]
    private float rushTowardsPlayerSpeedMultiplier = 10f;

    public int health;

    [SerializeField]
    private float rotationSpeed = 1f;

    private GameObject player;
    private bool rotateTowardsPlayer;

    private Quaternion targetRotation;

    [SerializeField]
    private GameObject PowerUp;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Attack());

    }
    // Update is called once per frame
    void Update()
    {
        //enemy moving down
        transform.Translate(Vector2.down * Random.Range(minSpeed, maxSpeed) * Time.deltaTime);

        //
        if (rotateTowardsPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            Attack1();
        }

        if(health <= 0)
        {
            gameManager.enemiesKilled++;
            ChanceOfSpawningPowerUp(0.1f); //10% of dropping a powerup 
            Destroy(this.gameObject);
        }
    }

    private void ChanceOfSpawningPowerUp(float chance)
    {
        float randomValue = Random.value; // Random value between 0 and 1

        if (randomValue <= chance)
        {
            Instantiate(PowerUp, this.transform.position, Quaternion.identity);   
        }
    }

    private void Attack1()
    {

        // Calculate the direction from the enemy to the player
        Vector3 direction = player.transform.position - transform.position;

        //getting the direction 
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle += 90f;
        targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //smoothly rotating towards player direction
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    //sets variable rotateTowardsPlayer to true, rotates towards player in Update and it multiplies the speed
    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(2f);
        rotateTowardsPlayer = true;
        minSpeed *= rushTowardsPlayerSpeedMultiplier;
        maxSpeed *= rushTowardsPlayerSpeedMultiplier;
    }
}
