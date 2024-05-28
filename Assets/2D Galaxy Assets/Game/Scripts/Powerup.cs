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
    [SerializeField]
    private AudioClip _Clip;
    void Update()
    {
       transform.Translate(Vector3.down * _speed * Time.deltaTime);

       if(transform.position.y < 0-7)
       {
        Destroy(this.gameObject);
       }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {         
            Player player = other.GetComponent<Player>();

            AudioSource.PlayClipAtPoint(_Clip, Camera.main.transform.position, 1f);
        
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
            

            }
            
            Destroy(this.gameObject);
        
        }            

    }
}
