using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void Start()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                AudioManager.GetAudioPlayer("Music_Menu").Play();
                break;
            case 1:
                AudioManager.GetAudioPlayer("Music_Menu").Stop();
                AudioManager.GetAudioPlayer("Music_GameOver").Stop();
                AudioManager.GetAudioPlayer("Music_IntroGame").Play();
                AudioManager.GetAudioPlayer("Music_GameLoop").PlayDelayed(0.9f);
                break;
            case 2:
                AudioManager.GetAudioPlayer("Music_IntroGame").Stop();
                AudioManager.GetAudioPlayer("Music_GameLoop").Stop();
                AudioManager.GetAudioPlayer("Music_GameOver").Play();
                break;
        }
    }
    public void GoToNextScene() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    public void GoToPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
