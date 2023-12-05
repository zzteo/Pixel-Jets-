using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public int damage;
    [SerializeField]
    private float shootSpeed = 10;
    public int enemiesKilled;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * shootSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.gameObject.GetComponent<EnemyScript>() != null)
            {
                collision.gameObject.GetComponent<EnemyScript>().health -= damage;
                Destroy(this.gameObject);
            }  
            else
            {
                collision.gameObject.GetComponent<Enemy2Script>().health -= damage;
            }

        }
        else if (collision.gameObject.tag == "Boundry" || collision.gameObject.tag == "obstacle")
        {
            Destroy(this.gameObject);
        }
    }

}
