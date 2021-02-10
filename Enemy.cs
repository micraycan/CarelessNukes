using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosion;

    private GameObject player;
    private float speed = 1.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private ShakeCamera shakeCamera;
    private GameManager gameManager;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = this.GetComponent<Rigidbody2D>();
        shakeCamera = GameObject.FindObjectOfType<Camera>().GetComponent<ShakeCamera>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movement);
    }

    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.health--;

            soundManager.PlayExplosionSound();
            Instantiate(explosion, transform.position, Quaternion.identity);
            shakeCamera.ScreenShake();
            
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Projectile"))
        {
            gameManager.score++;

            soundManager.PlayExplosionSound();
            Instantiate(explosion, transform.position, Quaternion.identity);
            shakeCamera.ScreenShake();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
