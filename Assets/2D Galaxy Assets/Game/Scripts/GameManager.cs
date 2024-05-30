using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject bossPrefab; // Reference to the boss prefab
    public Transform bossSpawnPoint; // Point where the boss will be spawned
    public UIManager uiManager; // Reference to the UI Manager to check the score

    private bool bossSpawned = false; // To ensure the boss is only spawned once

    void Update()
    {
        CheckScoreAndSpawnBoss();
    }

    void CheckScoreAndSpawnBoss()
    {
        if (!bossSpawned && uiManager.GetScore() >= 50)
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        Instantiate(bossPrefab, bossSpawnPoint.position, bossSpawnPoint.rotation);
        bossSpawned = true;
    }
}
