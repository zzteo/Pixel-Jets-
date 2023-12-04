using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testProjectileScript : MonoBehaviour
{
    public int damage;
    [SerializeField]
    private float shootSpeed = 10;
    public int enemiesKilled;
    public GameObject hitParticle;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * shootSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyScript>().health -= damage;
            Instantiate(hitParticle, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "obstacle")
        {
            Instantiate(hitParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Boundry")
        {
            Destroy(this.gameObject);
        }
    }

}
