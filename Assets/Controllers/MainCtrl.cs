
using UnityEngine;
using UnityEngine.SceneManagement;
public enum ScenesIndex
{
    home=0,
    game=1,
    gameOver=2
}

public class MainCtrl : MonoBehaviour
{
     int scoreTemp = 0;

    public static MainCtrl instance;

    public void Start()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void GoToGame()
    {
        SceneManager.LoadSceneAsync((int)ScenesIndex.game);
    }
     
    public static void GoToHome()
    {
        SceneManager.LoadSceneAsync((int)ScenesIndex.home);

    }

    public static void GoToGameOver()
    {
    int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        int score = LevelCrlt.GetScore();
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", score);
        }
        SceneManager.LoadSceneAsync((int)ScenesIndex.gameOver);
    }

    public static  void SetScore(int scro)
    {
        instance.scoreTemp = scro;
    }
    public static int GetScore()
    {
        return instance.scoreTemp;
    }
}
