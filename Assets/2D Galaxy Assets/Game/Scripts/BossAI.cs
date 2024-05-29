using UnityEngine;

public class BossAI : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float attackInterval = 2f;
    private float attackTimer;
    private Vector3 startPosition;
    public float moveAmplitude = 2f;
    public float moveFrequency = 1f;
    
    private Health health;

    public GameObject laserPrefab; // Reference to the laser prefab
    public Transform firePoint; // Point from which the laser is fired

    void Start()
    {
        health = GetComponent<Health>();
        startPosition = new Vector3(-0.28f, 2.70f, 0);
        attackTimer = attackInterval;
    }

    void Update()
    {
        Move();
        HandleAttack();
    }

    void Move()
    {
        float offset = Mathf.Sin(Time.time * moveFrequency) * moveAmplitude;
        transform.position = new Vector3(startPosition.x + offset, transform.position.y, transform.position.z);
    }

    void HandleAttack()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            Attack();
            attackTimer = attackInterval;
        }
    }

    void Attack()
    {
        // Instantiate the laser prefab at the fire point
        Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerLaser"))
        {
            var projectile = health ;
            if (projectile != null)
            {
              // health.TakeDamage(projectile.damage);
                Destroy(collision.gameObject);
            }
        }
    }
}
