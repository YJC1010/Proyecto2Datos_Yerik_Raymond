using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameTime = 180f; // 3 minutos

    private BinarySearchTree bst = new BinarySearchTree();

    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            Debug.Log("Tiempo terminado");
            Time.timeScale = 0;
        }
    }

    public void InsertTokenValue(int value)
    {
        bst.Insert(value);
        Debug.Log("Added to BST: " + value);
        Debug.Log("Current InOrder: " + bst.InOrder());
    }
}
