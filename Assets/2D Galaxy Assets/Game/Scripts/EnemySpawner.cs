using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField]
    private GameObject _ememyPrefab;
    float spawnCooldown;
    const float spawnInterval= 1f;


    private void Update()
    {
        if (spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
            return;
        }
     
        StartCoroutine(EnemySpawnerRoutine());

        
    }

     public IEnumerator EnemySpawnerRoutine()
    {
      Instantiate(_ememyPrefab, _ememyPrefab.transform.position, Quaternion.identity);
      Debug.Log("SOY YO");
      spawnCooldown = spawnInterval; 
      yield return new WaitForSeconds(10.0f);
      
    } 
 
}