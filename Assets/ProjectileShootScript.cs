using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShootScript : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefabPowerUp1;
    [SerializeField]
    private GameObject projectilePrefabPowerUp2;
    [SerializeField]
    private GameObject projectilePrefabPowerUp3;

    [SerializeField]
    private Transform projectilePos;

    [SerializeField]
    private Transform projectilePosPowerUp3_1;

    [SerializeField]
    private Transform projectilePosPowerUp3_2;

    private float timer;
    private bool canShoot = true;
    [SerializeField]
    private float projectileDelayPowerUp1;
    [SerializeField]
    private float projectileDelayPowerUp2;
    [SerializeField]
    private float projectileDelayPowerUp3;

    public int powerUp = 1;

    [SerializeField]
    private float secondsBulletDissapearAfterPowerUp2;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        //the variable powerUp decides which powerup behavior the player will have 
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
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectilePrefabPowerUp1, projectilePos.position, Quaternion.identity);
                canShoot = false;
            }
        }

        if (!canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= projectileDelayPowerUp1)
            {
                canShoot = true;
                timer = 0;
            }
        }
    }

    private void PowerUp2()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {             
                var bullet1 = Instantiate(projectilePrefabPowerUp2, projectilePos.position, Quaternion.identity);
                var bullet2 = Instantiate(projectilePrefabPowerUp2, projectilePos.position, Quaternion.Euler(0f, 0f, -20f));
                var bullet3 = Instantiate(projectilePrefabPowerUp2, projectilePos.position, Quaternion.Euler(0f, 0f, 20f));
                var bullet4 = Instantiate(projectilePrefabPowerUp2, projectilePos.position, Quaternion.Euler(0f, 0f, -10f));
                var bullet5 = Instantiate(projectilePrefabPowerUp2, projectilePos.position, Quaternion.Euler(0f, 0f, 10f));

                Destroy(bullet1, secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet2, secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet3, secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet4, secondsBulletDissapearAfterPowerUp2);
                Destroy(bullet5, secondsBulletDissapearAfterPowerUp2);

                canShoot = false;
            }
        }

        if (!canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= projectileDelayPowerUp2)
            {
                canShoot = true;
                timer = 0;
            }
        }
    }

    private void PowerUp3()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(projectilePrefabPowerUp3, projectilePos.position, Quaternion.identity);
                Instantiate(projectilePrefabPowerUp3, projectilePosPowerUp3_1.position, Quaternion.identity);
                Instantiate(projectilePrefabPowerUp3, projectilePosPowerUp3_2.position, Quaternion.identity);
                canShoot = false;
            }
        }

        if (!canShoot)
        {
            timer += Time.deltaTime;

            if (timer >= projectileDelayPowerUp1)
            {
                canShoot = true;
                timer = 0;
            }
        }
    }
}
