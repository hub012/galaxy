using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f;
    public string targetTag = "Player"; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Health health = collision.gameObject.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
            }
        }
    }
}
