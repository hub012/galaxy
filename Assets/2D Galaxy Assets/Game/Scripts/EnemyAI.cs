using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAI : MonoBehaviour    
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    private float _speed = 5.0f;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        
        if (transform.position.y < -7)
        {
            float randomx = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomx, 7, 0);
        }
        
    }
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.tag == "Laser")
    {
        if(other.transform.parent != null)  
        {
            Destroy(other.transform.parent.gameObject);
        }
        Destroy(other.gameObject);
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
    else if (other.tag == "Player")
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            player.Damage();
        }
        Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
    
        Destroy(this.gameObject);
    }
}

}
