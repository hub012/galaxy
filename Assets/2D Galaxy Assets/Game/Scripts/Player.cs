using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerExplosionPrefab;
    public bool canTripleShoot = false;
    public bool isSpeedBoostActive = false;
    public int lives = 3;

    [SerializeField]
    private GameObject _laserPrefab;

    [SerializeField]
    private GameObject _tripleShotsPrefab;

    [SerializeField]
    private float _fireRate = 0.25f;
    [SerializeField]
    private float _canFire = 0.0f;

    [SerializeField]   
    private float _speed = 5.0f;

    private void Start()
    {
        //Current pos = new position
        //new Vector3(1,0,0)
        transform.position = new Vector3(0, 0, 0);
    }
    private void Update()
    {
        Movement();
        // if space key presed 
        //spawn laser at player position

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButton(0))
        {
           Shoot();
        }
    }
    private void Shoot()

    {
         if (Time.time > _canFire)
           {
                if (canTripleShoot == true)
                {
                    //Left
                    //Instantiate(_laserPrefab, transform.position + new Vector3(-0.55f, 0.06f, 0), Quaternion.identity);
                    //Center
                    //Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity); 
                    //Right
                    //Instantiate(_laserPrefab, transform.position + new Vector3(0.55f, 0.06f, 0), Quaternion.identity); 
                    
                    Instantiate(_tripleShotsPrefab, transform.position, Quaternion.identity);
                }
                
                 else
                    {
                        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                    }
                _canFire = Time.time + _fireRate;
                }
                
                
           }
    private void Movement()
    
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive == true)
        {
          transform.Translate(Vector3.right * _speed * 5.0f * horizontalInput * Time.deltaTime);
          transform.Translate(Vector3.up * _speed * 5.0f * verticalInput  * Time.deltaTime);
        }
        else
        {
          transform.Translate(Vector3.right * _speed * horizontalInput * Time.deltaTime);
          transform.Translate(Vector3.up * _speed * verticalInput  * Time.deltaTime);
        }

      if (transform.position.y > 4.2f)
      {
        transform.position = new Vector3(transform.position.x, 4.2f, 0);
      }
      else if (transform.position.y < -4.2f)
      {
        transform.position = new Vector3(transform.position.x, -4.2f, 0);
      }

      if (transform.position.x > 8)
      {
        transform.position = new Vector3(8, transform.position.y, 0);
      }
      else if (transform.position.x < -8)
      {
        transform.position = new Vector3(-8, transform.position.y, 0);
      }

      //if the player position on the x is greater than 9.5
      //Este codigo permite pasar el jugador de un lado al otro de la pantalla.

     // if (transform.position.x > 9.5f)
      {
       // transform.position = new Vector3(-9.5f, transform.position.y, 0);
      }
     // else if (transform.position.x < -9.5f)
      {
      //  transform.position = new Vector3(9.5f, transform.position.y, 0);
      }
 } 
    public void Damage()
  {
      lives--;
      if (lives < 1 )
      {
        Instantiate(_playerExplosionPrefab, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
      }
  }

    public void TripleShotPowerupOn()
    {
      canTripleShoot = true;
      StartCoroutine(TripleShotPowerDownRoutine());
    }

    public void SpeedBoostPowerupOn()
    {
      isSpeedBoostActive = true;
      StartCoroutine(SpeedBoostDownRoutine());
    }
    public IEnumerator TripleShotPowerDownRoutine()
    {
      yield return new WaitForSeconds(5.0f);
      canTripleShoot = false;
    } 

    public IEnumerator SpeedBoostDownRoutine()
    {
      yield return new WaitForSeconds(5.0f);
      isSpeedBoostActive = false; 
    }
 
}
