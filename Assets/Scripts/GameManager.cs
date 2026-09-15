using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject winScreen;
    public bool won { get; private set; }
    public bool outOfBounds { get; private set; }

    public void Win()
    {
        won = true;
        winScreen.SetActive(true);
    }

    public void OutOfBounds()
    {
        outOfBounds = true;
    }
}
