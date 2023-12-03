using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    [SerializeField]
    private float _shootSpeed;
    public int enemiesKilled;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * _shootSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            enemiesKilled++;
            //particles effect 
        }
        else if (collision.gameObject.tag == "Boundry")
        {
            Destroy(this.gameObject);
        }
    }
}
