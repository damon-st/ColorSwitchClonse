using UnityEngine;

public class OnClickPauseCrlt : MonoBehaviour
{

    public GameObject pauseCanvas;

    public void Pause()
    {
        pauseCanvas.SetActive(true); 
        Time.timeScale = 0.0f;
    }

    public void Resume()
    {
        pauseCanvas.SetActive(false);   
        Time.timeScale = 1.0f;
    }
}
