using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.3f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
        if (FindFirstObjectByType<PauseMenu>().GameIsPaused) return;

        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
        // tähän tulee hyökkäyskoodin funktionaalisuus - osutaanko vihuun, vahinkoa vihuun, hyökkäysanimaatio
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
