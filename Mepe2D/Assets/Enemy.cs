using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Vihollisen elämä")]
    public Animator animator;
    public int maxHealth = 100;
    public int currentHealth;


    [Header("Vihollisen hyökkäys")]
    public Transform attackPoint;
    public float attackRange = 0.1f;
    public LayerMask playerLayer;
    public Transform playerTransform;
    public int attackDamage = 20;
    public float attackCooldown = 2f;
    private float lastAttackTime = -Mathf.Infinity;


    void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown && playerTransform != null) 
        {
            TryAttack();
        }
    }

    void TryAttack() 
    {
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, playerLayer);

        if(hitPlayer != null)
        {
            Attack(hitPlayer);
        }
    }

    void Attack(Collider2D player)
    {
        lastAttackTime = Time.time;

        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null) //punainen taustaväri??
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Näytä painframe
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
        // Destroy(gameObject); // <-- tämä poistaa tätä skriptiä käsittelevän objektin
        this.enabled = false;

        //Debug.Log("Surmasit limanuljaskan");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
