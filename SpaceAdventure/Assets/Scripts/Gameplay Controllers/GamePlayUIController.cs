using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayUIController : MonoBehaviour
{

    [SerializeField] private Text waveInfotext, shipsDestroyedInfoTxt, meteorsDestroyedInfoTxt;

    private int waveCount, shipsDestroyedCount, meteorsDestroyedCount;
    public static GamePlayUIController instance;

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public int GetShipsDestroyedCount()
    {
        return shipsDestroyedCount;
    }

    public int GetMeteorsDestroyedCount()
    {
        return meteorsDestroyedCount;
    }

    public int GetWaveCount()
    {
        return waveCount;
    }

    public void SetInfo(int infoType)
    {
        switch (infoType)
        {
            case 1:
                waveCount++;
                waveInfotext.text = "Wave: " + waveCount;
                break;
            case 2:
                shipsDestroyedCount++;
                shipsDestroyedInfoTxt.text = shipsDestroyedCount + "x";
                break;
            case 3:
                meteorsDestroyedCount++;
                meteorsDestroyedInfoTxt.text = meteorsDestroyedCount + "x";
                break;
        }
    }
}
