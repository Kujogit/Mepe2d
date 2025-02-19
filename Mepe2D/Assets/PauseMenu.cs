using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; //t�m�n tarvii ett� voi viitata scenejen v�lill�

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false; // staattinen arvo; onko peli paussilla, oletuksena false

    public GameObject pauseMenuUI; //Canvaksen sis�ll� luotu pausemenu scripti tarvitsee gameobjectin ja t�m� raahataan sinne

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //jos pelaaja painaa nimenomaan esci�...
        {
            if (GameIsPaused) //Jos pause on totta
            {
                Resume(); //niin jatka peli�
            }

            else //jos pause ei ole totta, pauseta
                {
                    Pause();
                }
            }
        }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);

        GameIsPaused = false;

        Time.timeScale = 1f; //Resumen aikana aika kulkee normaalisti
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        GameIsPaused = true;

        Time.timeScale = 0f; //Pausen aikana aika ei kulje, pelaajan komennot menee silti l�pi...
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; //ajan on pakko py�ri� menussakin ettei tule softlock

        SceneManager.LoadScene(0); //Tuohon numeroon toimisi my�s ("MainMenu") t�ss� mutta ei v�ltt�m�tt� kannata hardcodata
    }

    public void QuitGame()
    {
        Application.Quit(); // ei varmistusta yms, sulkee pelin

        Debug.Log("Quitting Game");
    }

}

