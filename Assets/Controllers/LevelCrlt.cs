using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCrlt : MonoBehaviour
{

    public TextMeshProUGUI textCount;
    int  score = 0;
   static LevelCrlt current;


    private void Awake()
    {
        if(current !=null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
       // DontDestroyOnLoad(gameObject);
    }

    public static int GetScore() { 
        return current.score;
    }

    public static void AumentarPuntaje(int value)
    {
        if(current == null)
        {
            return;
        }
        current.score = current.score+ value;
        Debug.Log("SCORE: "+current.score);
        current.textCount.text = current.score.ToString();  
    }
   
    public static void ResetScore()
    {
        current.score = 0;
    }

    private void OnDestroy()
    {
        MainCtrl.SetScore(score);
    }
}
