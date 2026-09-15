using UnityEngine;

public class Bounds : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.OutOfBounds();
        }
    }
}
