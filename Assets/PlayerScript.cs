using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float _horizontalSpeed;
    [SerializeField]
    private float _verticalSpeed;
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * _horizontalSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * _horizontalSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * _verticalSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * _verticalSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Time.timeScale = 0;
        }
    }
}
