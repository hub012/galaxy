using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public float damageAmount = 10f;
    public string targetTag = "Player"; 

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(targetTag))
        {
           
        }
        Debug.Log("" + other.gameObject.tag + "");
        Debug.Log("" + this.gameObject.tag + "");
        switch (other.gameObject.tag) {
            case "Player":
                Player player = other.gameObject.GetComponent<Player>();
                if (player != null){
                    Debug.Log("" + player.name + "");
                    player.Damage();
                }
            break;
            case "Enemy":
                Health health = other.gameObject.GetComponent<Health>();
                if (health != null)
                {
                    health.TakeDamage(damageAmount);
                }
            break;
            default:    
            break;
        }
    }
}
