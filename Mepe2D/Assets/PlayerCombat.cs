using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        // tähän tulee hyökkäyskoodin funktionaalisuus - osutaanko vihuun, vahinkoa vihuun, hyökkäysanimaatio
    }
}
