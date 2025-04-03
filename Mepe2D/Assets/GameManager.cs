using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public float playerHealth = 100f;

    void Awake()
    {
        //jos gamemanageria ei löydy
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //jos instanssi ei ole null = gamemanager löytyy jo
        else
        {
            Destroy(gameObject);
        }
    }
}
