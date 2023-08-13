using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCirclesCrlt : MonoBehaviour
{
    public static ContainerCirclesCrlt instance;

    public List<GameObject> circles = new List<GameObject>();
    public Transform circleCenter;
    public Transform changedColorCenter;
    public BoxCollider2D containerCollaider;
    public GameObject changeColorPref;
    private GameObject circleInstance;
    // Start is called before the first frame update
    private float positiony;
    private float sizeY;

    private List<GameObject> prefabsDestroyed = new List<GameObject>();

    void Start()
    {
        if(circleInstance != null && circleInstance!=this)
        {
            Destroy(gameObject);
        }
        instance = this;
        sizeY = containerCollaider.size.y;
        positiony = transform.position.y;   
        SetData();
       
    }

    void SetData()
    {
        int positon = Random.Range(0, circles.Count);
        GameObject temp = circles[positon];
        float postY = circleCenter.position.y - temp.transform.position.y;
        if (positon != 0)
        {
            postY= circleCenter.position.y + temp.transform.position.y+ (sizeY/4);
        }
        circleInstance = Instantiate(temp, new Vector3(circleCenter.position.x, postY, circleCenter.position.z), Quaternion.identity);
        prefabsDestroyed.Add(circleInstance);
        Instantiate(changeColorPref, changedColorCenter.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
   static public void CreateNewCircle()
    {
        instance. transform.position = new Vector3(instance.transform.position.x, instance.positiony + instance.sizeY, instance.transform.position.z);
        instance.positiony = instance.transform.position.y;
        Debug.Log("ENTRO EXID COLAIDER");
        instance.OnDestroyPrefabs();
        instance.SetData();
    }


    void OnDestroyPrefabs()
    {
        Invoke("DelayDestroyPrefs",1f);
    }

    void DelayDestroyPrefs()
    {
        if(prefabsDestroyed.Count > 0)
        {
            Destroy(prefabsDestroyed[0]);
        }
    }
}
