using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    private float _minSpeed = .3f;
    [SerializeField]
    private float _maxSpeed = .5f;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Attack());
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Random.Range(_minSpeed, _maxSpeed) * Time.deltaTime);

    }

    private IEnumerator Attack()
    {
        yield return new WaitForSeconds(3f);


        // Calculate the direction from the enemy to the player
        Vector3 direction = _player.transform.position - transform.position;

        // Calculate the angle in radians and convert to degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Create a rotation based on the calculated angle
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Smoothly rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 100 * Time.deltaTime);

        _minSpeed *= 10;
        _maxSpeed *= 10;
    }
}
