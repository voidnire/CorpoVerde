using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed = 2;
    [SerializeField] private GameObject destroyEffect;

    [SerializeField] private float damage = 5f;
    [SerializeField] private float health = 10f;

    [SerializeField] private int experienceToGive;

    [SerializeField] private Animator animator;

    [SerializeField] private float pushTime;
    private float pushCounter;

    [SerializeField] private float attackCooldown = 1.5f;
    private float attackTimer;
    private bool isCollidingWithPlayer = false;

    


    void Update()
    {
        if (!isCollidingWithPlayer) return;

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0f)
        {
            Attack();
            attackTimer = attackCooldown;
        }
    }


    void FixedUpdate()
    {
        if (PlayerController.Instance.gameObject.activeSelf) // se tiver player
        {
            //if (PlayerController.Instance.playerMoveDirection.x > 0)
            // faces the player
            if (PlayerController.Instance.transform.position.x >
                transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
            // push back
            if(pushCounter > 0)
            {
                pushCounter -= Time.fixedDeltaTime;
                if(moveSpeed > 0){
                    moveSpeed = -moveSpeed;
                }
                
            } else
            {
                moveSpeed = Mathf.Abs(moveSpeed);
            }

            //move towards the player
            direction = (PlayerController.Instance.transform.position -
                transform.position).normalized;
            rb.linearVelocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else // se não tiver player
        {
            rb.linearVelocity = Vector2.zero; // inimigo para de andar 
        }           
    }

    private void Attack()
    {
        animator.SetTrigger("isAttacking");
        PlayerController.Instance.TakeDamage(damage);
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            attackTimer = 0f; // ataca imediatamente ao encostar
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = false;
            //animator.SetTrigger("isAttacking");
        }
    }


    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.zero;
        spriteRenderer.flipX = false;

    }*/

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        DamageNumberController.Instance.CreateNumber(damageAmount, transform.position, Color.green);

        pushCounter = pushTime;


        if  (health <= 0)
        {
            Destroy(gameObject); //MORRE
            Instantiate(destroyEffect, transform.position, transform.rotation); //copy do prefab de destroy
            PlayerController.Instance.GetExperience(experienceToGive);
        }
    }

}
