using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverCrtl : MonoBehaviour
{
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textBestScore;
    int bestScore = 0;
    // Start is called before the first frame update
    void Start()
    {
      bestScore=  PlayerPrefs.GetInt("bestScore",0);
      textBestScore.text = bestScore.ToString();
        textScore.text = LevelCrlt.GetScore().ToString();
    }

    
    public void BackToHome()
    {
        MainCtrl.GoToHome();
    }

    public void ReatryGame()
    {
        MainCtrl.GoToGame();
    }
}
