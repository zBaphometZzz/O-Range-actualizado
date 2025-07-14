using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    public string GameOver;
    private Shooter shooter;
    private Rigidbody2D rig;
    private AudioSource playerSound;
    private bool isAlive;
    private EnemyController enemyController;
    private SpriteRenderer playerSprite;

    [SerializeField] private int playerLife;
    [SerializeField] ParticleSystem particles;


    private void Awake()
    {
        shooter = GetComponentInChildren<Shooter>();
        rig = GetComponent<Rigidbody2D>();
        enemyController = FindObjectOfType<EnemyController>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        isAlive = true;
        UIController.instance.SetLife(playerLife);
    }

    private void Update()
    {
        Shooting();
        playerSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (isAlive)
        {
            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            rig.linearVelocity = new Vector2(movX, movY) * speed;
        }
    }

    private void Shooting()
    {
       if (Input.GetMouseButtonDown(0))
       {
           // playerSound.Play ();
            shooter.Shooting();
       }
    }

    public void Hurt(int hurt)
    {
        playerLife -= hurt;
        UIController.instance.SetLife(playerLife);

        if (playerLife <= 0)
        {
            SceneManager.LoadScene(GameOver);

            isAlive = false;

            
            
            playerSprite.enabled = false;
            particles.Play();
        }
     
    }
}
