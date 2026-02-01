using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5;

    public Vector3 playerMoveDirection;

    public float playerMaxHealth = 100;
    public float playerCurrentHealth;

    [SerializeField] private Animator animator;

    private bool isImmune;
    [SerializeField] private float immunityDuration = 2f;
    [SerializeField] private float immunityTimer;

    private Collectible collectibleNearby;
    private PlayerInventory inventory;

    public int experience;

    void Start()
    {
        playerCurrentHealth = playerMaxHealth;

        UIController.Instance.UpdateHealthSlider();
        UIItensController.Instance.UpdateLatexText(0);

        UIItensController.Instance.UpdateFrutasText(0);

        inventory = GetComponent<PlayerInventory>();

        if (inventory == null)
            Debug.LogError("PlayerInventory NÃO está neste GameObject");
        else
            Debug.Log(" PlayerInventory encontrado");
    }

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }else
            Instance = this; 
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
        playerMoveDirection = new Vector3(inputX, inputY).normalized;

        FlipCharacterX(playerMoveDirection);


        /*      ANIMAÇÃO    */
        if (playerMoveDirection == Vector3.zero)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        } 
        /*      ANIMAÇÃO     */ 
        
        /* IMUNIDADE */
        if(immunityTimer > 0)
            immunityTimer -= Time.deltaTime;
        else
            isImmune = false;

        if (collectibleNearby != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("COLETAANDO ITEM....");
            collectibleNearby.Collect(inventory);
            collectibleNearby = null;
        }
    }

    private void FlipCharacterX(Vector3 playerMoveDirection)
    {
        if (playerMoveDirection.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (playerMoveDirection.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerMoveDirection.x * moveSpeed,
            playerMoveDirection.y * moveSpeed);
    }

    public void TakeDamage(float damageAmount)
    {
        if (!isImmune)
        {
            Debug.Log(" PLAYER TOMOU DANO");
            isImmune = true;
            immunityTimer = immunityDuration;

            DamageNumberController.Instance.CreateNumber(damageAmount, transform.position, Color.red);
            playerCurrentHealth -= damageAmount;

            UIController.Instance.UpdateHealthSlider();
            if (playerCurrentHealth <= 0)
            {
                gameObject.SetActive(false);
                Debug.Log("Player Died");
                GameManager.Instance.GameOver();
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            Debug.Log("Collectible nearby");
            collectibleNearby = other.GetComponent<Collectible>();
            UXController.Instance.CreateCollectPrompt(transform.position);
        }
    }

    public void GetExperience(int experienceToGet)
    {
        experience += experienceToGet;
    }

    /*void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Collectible"))
        {
            collectibleNearby = null;
            UXController.Instance.HideCollectPrompt();

        }
    }*/
}
