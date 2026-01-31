using UnityEngine;

public class SementeBehavior : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private LayerMask whatDestroysBullet;
    [SerializeField] private int damage = 5;

    private bool destroyed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();

        SetStraightVelocity();
    }

    private void SetStraightVelocity()
    {
        rb.linearVelocity = transform.right * speed;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime); // Destrói o objeto após 3 segundos
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyed)
            return;

        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Semente hit an enemy!");
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
                enemy.TakeDamage(damage);

            destroyed = true;
            Destroy(gameObject);
        }
    }


}
