using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUIController : MonoBehaviour
{
    public static GameOverUIController instance;

    [SerializeField] private Canvas playerInfoCanvas, shipsAndMeteorInfoCanvas, gameOverCanvas;
    [SerializeField] private Text shipsDestroyedFinalInfoTxt, meteorsDestroyedFinalInfoTxt, WaveFinalInfoTxt;
    [SerializeField] private Text shipsDestroyedHighscoreTxt, meteorsDestroyedHighscoreTxt, waveHighscoreTxt;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    public void OpenGameOverPanel()
    {
        //playerInfoCanvas.enabled = false;
        //shipsAndMeteorInfoCanvas.enabled = false;

        playerInfoCanvas.enabled = shipsAndMeteorInfoCanvas.enabled = false;

        gameOverCanvas.enabled = true;

        int shipsDestroyedFinal = GamePlayUIController.instance.GetShipsDestroyedCount();
        int meteorsDestroyedFinal = GamePlayUIController.instance.GetMeteorsDestroyedCount();
        int waveCountFinal = GamePlayUIController.instance.GetWaveCount();

        waveCountFinal--;

        shipsDestroyedFinalInfoTxt.text = "x" + shipsDestroyedFinal;
        meteorsDestroyedFinalInfoTxt.text = "x" + meteorsDestroyedFinal;
        WaveFinalInfoTxt.text = "Wave: " + waveCountFinal;

        //calculate highscore
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
    }
}
