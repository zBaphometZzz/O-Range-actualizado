using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float speed = 1f;
    private float fixedX; // Store the initial X position

    private void OnEnable()
    {
        transform.position = transform.parent.position;
        fixedX = transform.position.x; // Save the initial X position
    }

    private void Update()
    {
        // Keep X position fixed while moving upwards
        transform.position = new Vector2(fixedX, transform.position.y + speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);
            AlienShip alienShip = collision.GetComponent<AlienShip>();
            // alienShip.Exploit();
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("Boss"))
        {
            this.gameObject.SetActive(false);
            FinalBoss finalBoss = collision.GetComponent<FinalBoss>();
            finalBoss.SubtracLives();
        }
    }
}