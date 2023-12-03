using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    [SerializeField]
    private float _minSpeed = .3f;
    [SerializeField]
    private float _maxSpeed = .5f;

    public int health;

    [SerializeField]
    private float rotationSpeed = 10f;

    private GameObject _player;
    private bool _rotateTowardsPlayer;

    private Quaternion targetRotation;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Attack());

    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Random.Range(_minSpeed, _maxSpeed) * Time.deltaTime);

        if (_rotateTowardsPlayer)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            Attack1();
        }

        if(health <= 0)
        {
            gameManager.enemiesKilled++;
            gameManager.increasedSpeed = false;
            Destroy(this.gameObject);

        }
    }

    private void Attack1()
    {

        // Calculate the direction from the enemy to the player
        Vector3 direction = _player.transform.position - transform.position;

        // Calculate the angle in radians and convert to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle += 90f; // You may need to tweak this value based on your sprite

        targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(3f);
        _rotateTowardsPlayer = true;
        _minSpeed *= 10;
        _maxSpeed *= 10;
    }
}
