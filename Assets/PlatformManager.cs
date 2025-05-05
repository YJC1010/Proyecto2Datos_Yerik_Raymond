using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int platformCount = 5;
    public float minX = -5f, maxX = 5f, minY = -4f, maxY = 5f;

    void Start()
    {
        for (int i = 0; i < platformCount; i++)
        {
            Vector2 position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(platformPrefab, position, Quaternion.identity);
        }
    }
}
