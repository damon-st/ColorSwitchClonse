using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleChangedCtrl : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    
    private List<Color> colorList = new List<Color>();  

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        colorList.Add(Color.cyan);
        colorList.Add(Color.magenta);
        colorList.Add(Color.red);
        colorList.Add(Color.yellow);
        StartCoroutine(ChangedColor());
    }

    IEnumerator ChangedColor()
    {
        while (true)
        {
            spriteRenderer.color = colorList[Random.Range(0,colorList.Count)];
            yield return new WaitForSeconds(0.3f);
        }

    }

    private void OnDestroy()
    {
        StopCoroutine(ChangedColor());

    }
}
