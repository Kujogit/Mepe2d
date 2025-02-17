using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthAmount = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.AddHealth(healthAmount);
        }
        Destroy(gameObject);
    }
}
