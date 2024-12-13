using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float attackRange = 1f;
    public int health = 100;
    public GameObject player1;
    public GameObject player2;
    public GameObject deathEffectPrefab;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool isAttacking = false;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (!isAttacking)
        {
            MoveTowardsPlayer();
        }
    }

    void MoveTowardsPlayer()
    {
        float distanceToPlayer1 = Vector2.Distance(transform.position, player1.transform.position);
        float distanceToPlayer2 = Vector2.Distance(transform.position, player2.transform.position);

        if (distanceToPlayer1 < distanceToPlayer2)
        {
            moveDirection = (player1.transform.position - transform.position).normalized;
        }
        else
        {
            moveDirection = (player2.transform.position - transform.position).normalized;
        }

        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

        if (distanceToPlayer1 < attackRange || distanceToPlayer2 < attackRange)
        {
            StartCoroutine(Attack());
        }

        animator.SetTrigger("Move");
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("Attack");
        // Implement attack logic here
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetTrigger("Die");
        Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            // Implement enemy spawning logic here
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Tether"))
        {
            // Implement interaction with tether here
        }
    }
}
