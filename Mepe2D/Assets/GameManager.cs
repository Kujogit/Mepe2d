using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public float playerHealth = 100f;

    void Awake()
    {
        //jos gamemanageria ei l�ydy
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //jos instanssi ei ole null = gamemanager l�ytyy jo
        else
        {
            Destroy(gameObject);
        }
    }
}
