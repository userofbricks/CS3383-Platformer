using UnityEngine;

public class BackgroundControler : MonoBehaviour
{
    private float startPos, length;
    public GameObject camera;
    public float parallaxEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {
        UpdateParallax(camera.transform.position.x);
    }

    private void UpdateParallax(float posX)
    {
        float distance = posX * parallaxEffect;
        float movement = posX * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if(movement > startPos + length) {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
