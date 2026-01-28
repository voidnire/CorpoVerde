using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 4;
    public Vector3 playerMoveDirection;

    void Start()
    {
        
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector2(inputX, inputY).normalized;

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed,
            playerMoveDirection.y * moveSpeed);
    }
}
