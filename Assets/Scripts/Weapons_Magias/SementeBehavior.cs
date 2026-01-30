using UnityEngine;

public class SementeBehavior : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private int damage = 10;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetDestroyTime();

        SetStraightVelocity();
    }

    private void SetStraightVelocity()
    {
        float speed = 10f; // Define a velocidade da semente
        rb.linearVelocity = transform.right * speed;
    }

    private void SetDestroyTime()
    {
        Destroy(gameObject, destroyTime); // Destrói o objeto após 3 segundos
    }
}
