using UnityEngine;

public class AsteroidRingSetup : MonoBehaviour
{
    public GameObject[] asteroids;
    public float radius = 5f;

    void Start()
    {
        PositionAsteroidsInRing();
    }

    void PositionAsteroidsInRing()
    {
        int numberOfAsteroids = asteroids.Length;
        float angleStep = 360f / numberOfAsteroids;

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            float angle = i * angleStep * Mathf.Deg2Rad;
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;

            asteroids[i].transform.position = new Vector3(x, y, 0) + transform.position;
        }
    }
}
