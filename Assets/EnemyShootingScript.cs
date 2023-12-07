using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootingScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyProjectile;

    [SerializeField]
    private Transform shootingStartPosition;

    public float shootingDelay;

    private void Start()
    {
        InvokeRepeating("Shoot", 2f, shootingDelay);
    }
    private void Shoot()
    {
        Instantiate(enemyProjectile, shootingStartPosition.position, Quaternion.identity);
    }
}
