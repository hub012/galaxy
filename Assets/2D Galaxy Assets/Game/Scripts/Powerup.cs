using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    // Start is called before the first frame update
        
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int PowerupID; //0 = disparo triple, 1= speed boot, 2 = shields 
    // PowerupID |0|1|2
    //

    //String[] -> []
    //enum{"TripleShot"}
    // Update is called once per frame
    //Si choco con X collider activame
    // Tendo 3 poweruops
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
            // Quien soy yo
            // Determinaar segun quien soy
            // Si soy speed activo speed
            Player player = other.GetComponent<Player>();
        
            if (player != null)
            {
              /*  if (PowerupID == 0)
                {
                    player.TripleShotPowerupOn();
                }
                else if (PowerupID == 1)
                {
                    player.SpeedBoostPowerupOn();
                }
                else if (PowerupID == 2)
                {

                }*/
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
