using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 20f;
    public float initialRadius = 5f;
    public float radiusChangeSpeed = 1f;
    public bool increaseRadius = true;
    private float currentRadius;
    private Transform[] asteroids;

    void Start()
    {
        // Initialize the current radius
        currentRadius = initialRadius;

        // Get all child asteroid transforms
        int childCount = transform.childCount;
        asteroids = new Transform[childCount];
        for (int i = 0; i < childCount; i++)
        {
            asteroids[i] = transform.GetChild(i);
        }

        PositionAsteroidsInRing();
    }

    void Update()
    {
        // Rotate the entire ring of asteroids around the center
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        // Update the radius dynamically
        UpdateRadius();

        // Reposition asteroids based on the updated radius
        PositionAsteroidsInRing();
    }

    void UpdateRadius()
    {
        if (increaseRadius)
        {
            currentRadius += radiusChangeSpeed * Time.deltaTime;
        }
        else
        {
            currentRadius -= radiusChangeSpeed * Time.deltaTime;
        }

        // Toggle the direction of radius change at certain limits
        if (currentRadius > 3f)
        {
            increaseRadius = false;
        }
        else if (currentRadius < 1f)
        {
            increaseRadius = true;
        }
    }

    void PositionAsteroidsInRing()
    {
        int numberOfAsteroids = asteroids.Length;
        float angleStep = 360f / numberOfAsteroids;

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * currentRadius;
            float y = Mathf.Sin(angle) * currentRadius;

            asteroids[i].localPosition = new Vector3(x, y, 0);
        }
    }
}
