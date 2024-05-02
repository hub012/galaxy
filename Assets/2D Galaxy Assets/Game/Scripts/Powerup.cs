using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
        
    [SerializeField]
    private float _speed = 3.0f;
  
    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
        
            if (player != null)
            {
                player.canTripleShoot = true;
            }
        
            Destroy(this.gameObject);
        
        }
            


    }
}
