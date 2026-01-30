using System.Threading;
using UnityEngine;

public class SementePrefab : MonoBehaviour
{
    //public Semente semente;

    private float damage;
    private Rigidbody2D rb;

    private bool destroyed;


    public float lifetime = 3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector2 direction, float speed, float dmg)
    {
        damage = dmg;
        rb.linearVelocity = direction * speed;
        //Destroy(gameObject, lifetime);
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if(destroyed)
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
