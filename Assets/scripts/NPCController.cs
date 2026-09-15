using UnityEngine;

public class NPCController : MonoBehaviour
{
    public float left = 12f;
    public float right = 18f;
    public float speed = 2f;
    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
        if (transform.position.x >= right)
            direction = -1;
        else if (transform.position.x <= left)
            direction = 1;

    }
}
