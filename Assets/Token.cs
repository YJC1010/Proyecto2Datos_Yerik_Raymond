using UnityEngine;

public class Token : MonoBehaviour
{
    public int value;
    public TextMesh numberText;

    private void Start()
    {
        numberText.text = value.ToString();
    }

    public void Initialize(int randomValue)
    {
        value = randomValue;
        if (numberText != null)
        {
            numberText.text = value.ToString();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BinarySearchTree bst = FindObjectOfType<BinarySearchTree>();
            if (bst != null)
            {
                bst.Insert(value);
            }

            Destroy(gameObject); // destruir el token al tomarlo
        }
    }
}
