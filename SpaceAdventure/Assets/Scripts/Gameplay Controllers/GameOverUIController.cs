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
        CalculateHighscore(shipsDestroyedFinal, meteorsDestroyedFinal, waveCountFinal);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(TagManager.GAMEPLAY_LEVEL_NAME);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(TagManager.MAIN_MENU_LEVEL_NAME);
    }

    void CalculateHighscore(int shipsDestroyedCurrent, int meteorsDestroyedCurrent, int waveCurrent)
    {
        int shipsDestroyed_Highscore = DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        int meteorsDestroyed_Highscore = DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        int wave_Highscore = DataManager.GetData(TagManager.WAVE_NUMBER_DATA);

            if(shipsDestroyedCurrent > shipsDestroyed_Highscore)
                DataManager.SaveData(TagManager.SHIPS_DESTROYED_DATA, shipsDestroyedCurrent);

            if(meteorsDestroyedCurrent > meteorsDestroyed_Highscore)
                DataManager.SaveData(TagManager.METEORS_DESTROYED_DATA, meteorsDestroyedCurrent);

            if(waveCurrent > wave_Highscore)
                DataManager.SaveData(TagManager.WAVE_NUMBER_DATA, waveCurrent);

        shipsDestroyedHighscoreTxt.text = "x" + DataManager.GetData(TagManager.SHIPS_DESTROYED_DATA);
        meteorsDestroyedHighscoreTxt.text = "x" + DataManager.GetData(TagManager.METEORS_DESTROYED_DATA);
        waveHighscoreTxt.text = "Wave: " + DataManager.GetData(TagManager.WAVE_NUMBER_DATA);
    }
}
