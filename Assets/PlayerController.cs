using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float lastJumpTime = -1f;  // Guarda el tiempo del último salto
    private float jumpCooldown = 1f;   // Tiempo mínimo entre saltos (1 segundo)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento lateral con WASD
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Saltar si se presiona espacio y ha pasado 1 segundo desde el último salto
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastJumpTime >= jumpCooldown)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            lastJumpTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        // Movimiento en el plano
        rb.MovePosition(rb.position + new Vector2(movement.x, movement.y) * moveSpeed * Time.fixedDeltaTime);
    }


    public BinarySearchTree bst = new BinarySearchTree();


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Token"))
        {
            int value = other.GetComponent<Token>().value;
            bst.Insert(value);
            Debug.Log("Added to BST: " + value);
            Debug.Log("Current InOrder: " + bst.InOrder());
            Destroy(other.gameObject);
        }
    }


}

