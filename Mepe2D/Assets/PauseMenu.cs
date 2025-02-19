using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement; //tämän tarvii että voi viitata scenejen välillä

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false; // staattinen arvo; onko peli paussilla, oletuksena false

    public GameObject pauseMenuUI; //Canvaksen sisällä luotu pausemenu scripti tarvitsee gameobjectin ja tämä raahataan sinne

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //jos pelaaja painaa nimenomaan esciä...
        {
            if (GameIsPaused) //Jos pause on totta
            {
                Resume(); //niin jatka peliä
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

        Time.timeScale = 0f; //Pausen aikana aika ei kulje, pelaajan komennot menee silti läpi...
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f; //ajan on pakko pyöriä menussakin ettei tule softlock

        SceneManager.LoadScene(0); //Tuohon numeroon toimisi myös ("MainMenu") tässä mutta ei välttämättä kannata hardcodata
    }

    public void QuitGame()
    {
        Application.Quit(); // ei varmistusta yms, sulkee pelin

        Debug.Log("Quitting Game");
    }

}

