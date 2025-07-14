using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{
    private float speed = 1f;

    private void Start()
    {
        Invoke(nameof(DestroyLaser), 3f);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            playerController.Hurt(1);
            this.gameObject.SetActive(false);
        }
    }

    private void DestroyLaser()
    {
        Destroy(this.gameObject);
    }
}   
