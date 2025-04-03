using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public Image healthBar;
    public Animator animator;


    void Start()
    {
        //tallentaa healthin gamemanageriin
        if (GameManager.instance != null)
        {
            currentHealth = GameManager.instance.playerHealth;
        }
        else
        {
            currentHealth = maxHealth;
        }
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
        GameManager.instance.playerHealth = currentHealth;
    }

    public void AddHealth(int health)
    {
        currentHealth += health;

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("TakeDamage");

        if (currentHealth <= 0) 
        {
            Die();
        }
    }


    void Die()
    {
        //hudissa hp:t menee täysille ennenkuin kuollaan, pitäisi laittaa paneeli peittämään kuoleman ajaksi, esim overlay
        currentHealth = maxHealth;
        GameManager.instance.playerHealth = currentHealth; 


        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
