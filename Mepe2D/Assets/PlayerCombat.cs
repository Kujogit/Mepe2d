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
        // t�h�n tulee hy�kk�yskoodin funktionaalisuus - osutaanko vihuun, vahinkoa vihuun, hy�kk�ysanimaatio
    }
}
