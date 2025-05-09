using UnityEngine;

public class Token : MonoBehaviour
{
    public int value;
    public TextMesh numberText;
    public string ownerTag; // Player1 o Player2

    public void Initialize(int randomValue)
    {
        value = randomValue;
        numberText.text = value.ToString();
    }
}

