using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelChange : MonoBehaviour
{
    public int sceneIndex;
    public GameObject loadingScreen; //viittaa canvasin sis�ll� olevaan loadingScreeniin

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.tag == "Player") //jos pelaaja osuu colliderillaan niin ...
        {
            StartCoroutine(LoadSceneAsync(sceneIndex));
        }
    }

    IEnumerator LoadSceneAsync(int index)
    {
        //aktivoidaan LoadingScreen
        if (loadingScreen != null) //jos loadingscreen ei ole p��ll� niin
        loadingScreen.SetActive(true);

        //aloitetaan uuden scenen lataus
        AsyncOperation operation = SceneManager.LoadSceneAsync(index); //loadingscreenin taustalla ladataan uutta scene�/tasoa
        operation.allowSceneActivation = false; //ei p��stet� pelaajaa toiseen sceneen/tasoon (viel�!)

        //aktivoidaan uusi scene
        while (!operation.isDone)
        {
            if(operation.progress >= 0.9f) // jos latausprogress tasan tai isompi kuin 90%
            {
                yield return new WaitForSeconds(1f); //pakotetaan sekunnin odotusaika ja sitten
                operation.allowSceneActivation = true; //vaihdetaan taso/Scene
            }
            yield return null;
        }
    }

}
