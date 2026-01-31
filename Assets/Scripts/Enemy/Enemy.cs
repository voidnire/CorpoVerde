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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.TakeDamage(damage);
            //PlayerController.Instance.ChangeHealth(-1);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        DamageNumberController.Instance.CreateNumber(damageAmount, transform.position);

        if  (health <= 0)
        {
            Destroy(gameObject); //MORRE
            Instantiate(destroyEffect, transform.position, transform.rotation); //copy do prefab de destroy
        }
    }

}
