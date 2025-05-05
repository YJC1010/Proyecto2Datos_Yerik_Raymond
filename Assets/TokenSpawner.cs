using UnityEngine;

public class TokenSpawner : MonoBehaviour
{
    public GameObject tokenPrefab;
    public float spawnInterval = 1f;
    public float minX = -8f;
    public float maxX = 8f;
    public float spawnY = 5f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnToken), 1f, spawnInterval);
    }

    void SpawnToken()
    {
        float randomX = Random.Range(minX, maxX);
        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        GameObject tokenObj = Instantiate(tokenPrefab, spawnPosition, Quaternion.identity);
        Token tokenScript = tokenObj.GetComponent<Token>();

        int randomValue = Random.Range(1, 100);
        tokenScript.Initialize(randomValue);
    }

}
