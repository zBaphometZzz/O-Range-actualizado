using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    public string win;
    public Transform bossPosition;
    private bool startAttack;
    private Animator anim;
    private SpriteRenderer bossSprite;
    private BoxCollider2D col;
    private bool isDestroyed;
    private AudioSource bossSound;

    [SerializeField] int bossLives;
    [SerializeField] float bossSpeed;
    [SerializeField] ParticleSystem[] arrayDestroyBoss;
    [SerializeField] GameObject shooter;

    [SerializeField] Transform leftLimit;  // L�mite izquierdo
    [SerializeField] Transform rightLimit; // L�mite derecho
    private bool movingRight = true;       // Direcci�n actual del movimiento

    private void Awake()
    {
        bossSound = GetComponent<AudioSource>();
        //anim = GetComponent<Animator>();
        bossSprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();

        // Define la posici�n inicial como el l�mite izquierdo
        bossPosition = leftLimit;
    }

    private void Start()
    {
        anim.enabled = false;
        StartCoroutine(BossShooting());  // Comienza la corutina al inicio
    }

    private void Update()
    {
        // Mover al jefe hacia la posici�n objetivo (bossPosition)
        transform.position = Vector2.MoveTowards(transform.position, bossPosition.position, bossSpeed * Time.deltaTime);

        // Cambiar de direcci�n al alcanzar el destino
        if (transform.position == bossPosition.position && !startAttack)
        {
            // Alterna entre los l�mites
            bossPosition = movingRight ? rightLimit : leftLimit;
            movingRight = !movingRight; // Cambia la direcci�n
        }
    }

    private void AttackPosition()
    {
        anim.enabled = true;
        anim.SetTrigger("StartAttack");
        StartCoroutine(BossShooting());  // Llama a la corutina para disparar
    }

    public void SubtracLives()
    {
        bossLives--;
        if (bossLives <= 0)
        {
            SceneManager.LoadScene(win);
        }
    }

    private void DisableBoss()
    {
        isDestroyed = true;
        bossSprite.enabled = false;
        col.enabled = false;
        
        StartCoroutine(DestroyBoss());
    }

    IEnumerator DestroyBoss()
    {
        for (int i = 0; i < arrayDestroyBoss.Length; i++)
        {
            arrayDestroyBoss[i].Play();
            bossSound.Play();
            yield return new WaitForSeconds(0.1f);
        }

        Invoke(nameof(Destruction), 2f);
    }

    IEnumerator BossShooting()
    {
        // La corutina se ejecutar� solo una vez cada 2 segundos.
        while (!isDestroyed)
        {
            yield return new WaitForSeconds(0.1f); // Espera 2 segundos entre disparos
            Instantiate(Resources.Load("EnemyLaser"), shooter.transform.position, Quaternion.identity); // Dispara
        }
    }

    private void Destruction()
    {
        SceneManager.LoadScene(win);
    }
}