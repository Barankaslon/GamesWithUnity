using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Canvas mainMenuCanvas, highscoreCanvas;
    [SerializeField] private Text shipDestroyedHighscore, meteorsDestroyedHighscore, waveSurvivedHighscore;

    public void Playgame()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void OpenCloseHighscoreCanvas(bool open) 
        {
            mainMenuCanvas.enabled = !open;
            highscoreCanvas.enabled = open;

            if(open)
                DisplayHighscore();
        }
    
    void DisplayHighscore()
    {
        
    }

}
