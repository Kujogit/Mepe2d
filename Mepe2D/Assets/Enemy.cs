using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //N�yt� painframe
        animator.SetTrigger("Hurt");

        if (currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);
        GetComponent<Collider2D>().enabled = false;
        // Destroy(gameObject); // t�m� poistaa spriten
        this.enabled = false;

        //Debug.Log("Surmasit limanuljaskan");
    }

}
