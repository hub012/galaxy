using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
        
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int PowerupID;
    void Update()
    {
       transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.tag == "Player")
        {
            Debug.Log("My name " + this.name);
            Debug.Log("My tag " + this.tag);
          
            Player player = other.GetComponent<Player>();
        
            if (player != null)
            {
                if (PowerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if (PowerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }
                else if (PowerupID == 2)
                {
                    player.EnableShields();
                }
                if (this.tag == "Triple_Shots_Powerup"){    
                        player.TripleShotPowerupOn();
                }
                if (this.tag == "Speed_Powerup"){
                    player.SpeedBoostPowerupOn();
                }

            }
            
            Destroy(this.gameObject);
        
        }            

    }
}
