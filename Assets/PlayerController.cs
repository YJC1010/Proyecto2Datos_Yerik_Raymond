using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public string horizontalInput = "Horizontal";
    public KeyCode jumpKey = KeyCode.Space;

    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private float lastJumpTime = -1f;
    private float jumpCooldown = 1f;

    private BinarySearchTree bst = new BinarySearchTree();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw(horizontalInput);

        if (Input.GetKeyDown(jumpKey) && Time.time - lastJumpTime >= jumpCooldown)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            lastJumpTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector2(movement.x, 0) * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Token"))
        {
            Token token = other.GetComponent<Token>();
            if (token != null && token.ownerTag == this.tag)
            {
                bst.Insert(token.value);
                Debug.Log(gameObject.name + " added to BST: " + token.value);
                Debug.Log(gameObject.name + " InOrder: " + bst.InOrder());
                Destroy(other.gameObject);
            }
        }
    }

}
