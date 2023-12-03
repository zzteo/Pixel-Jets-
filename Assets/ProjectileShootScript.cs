using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab;
    [SerializeField]
    private Transform _projectilePos;

    private float timer;
    private bool _canShoot = true;
    [SerializeField]
    private float _projectileDelay;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if (_canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(_projectilePrefab, _projectilePos.position, Quaternion.identity);
                _canShoot = false;        
            }
        }

        if (!_canShoot)
        {           
            timer += Time.deltaTime;

            if (timer >= _projectileDelay)
            {
                _canShoot = true;
                timer = 0;
            }
        }
       
    }
}
