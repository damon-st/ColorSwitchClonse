using UnityEngine;

public class EstrellaCtrl : MonoBehaviour
{

   public BoxCollider2D boxCollider;
    public int puntaje = 1;
   public void OnPlayStart()
    {
        LevelCrlt.AumentarPuntaje(puntaje);
        AudioManager.PlayStarSoung();
        boxCollider.enabled = false;
        Invoke("DeleteObj", 0.5f);
    }
    void DeleteObj()
    {
        Destroy(gameObject);
    }
}
