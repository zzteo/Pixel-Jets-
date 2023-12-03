using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefabPowerUp1;
    [SerializeField]
    private GameObject _projectilePrefabPowerUp2;
    [SerializeField]
    private GameObject _projectilePrefabPowerUp3;

    [SerializeField]
    private Transform _projectilePos;

    [SerializeField]
    private Transform _projectilePosPowerUp3_1;

    [SerializeField]
    private Transform _projectilePosPowerUp3_2;

    private float timer;
    private bool _canShoot = true;
    [SerializeField]
    private float _projectileDelayPowerUp1;
    [SerializeField]
    private float _projectileDelayPowerUp2;
    [SerializeField]
    private float _projectileDelayPowerUp3;

    public int powerUp = 1;

    [SerializeField]
    private float _secondsBulletDissapearAfterPowerUp2;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        if (powerUp == 1)
        {
            PowerUp1();
        }
        else if(powerUp == 2)
        {
            PowerUp2();
        }
        else if(powerUp == 3)
        {
            PowerUp3();
        }

       
    }

    private void PowerUp1()
    {
        if (_canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(_projectilePrefabPowerUp1, _projectilePos.position, Quaternion.identity);
                _canShoot = false;
            }
        }

        if (!_canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= _projectileDelayPowerUp1)
            {
                _canShoot = true;
                timer = 0;
            }
        }
    }

    private void PowerUp2()
    {
        if (_canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {             
                var bullet1 = Instantiate(_projectilePrefabPowerUp2, _projectilePos.position, Quaternion.identity);
                var bullet2 = Instantiate(_projectilePrefabPowerUp2, _projectilePos.position, Quaternion.Euler(0f, 0f, -20f));
                var bullet3 = Instantiate(_projectilePrefabPowerUp2, _projectilePos.position, Quaternion.Euler(0f, 0f, 20f));
                var bullet4 = Instantiate(_projectilePrefabPowerUp2, _projectilePos.position, Quaternion.Euler(0f, 0f, -10f));
                var bullet5 = Instantiate(_projectilePrefabPowerUp2, _projectilePos.position, Quaternion.Euler(0f, 0f, 10f));

                Destroy(bullet1, _secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet2, _secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet3, _secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet4, _secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet5, _secondsBulletDissapearAfterPowerUp2);

                _canShoot = false;
            }
        }

        if (!_canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= _projectileDelayPowerUp2)
            {
                _canShoot = true;
                timer = 0;
            }
        }
    }

    private void PowerUp3()
    {
        if (_canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(_projectilePrefabPowerUp1, _projectilePos.position, Quaternion.identity);
                Instantiate(_projectilePrefabPowerUp1, _projectilePosPowerUp3_1.position, Quaternion.identity);
                Instantiate(_projectilePrefabPowerUp1, _projectilePosPowerUp3_2.position, Quaternion.identity);
                _canShoot = false;
            }
        }

        if (!_canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= _projectileDelayPowerUp1)
            {
                _canShoot = true;
                timer = 0;
            }
        }
    }
}
