using UnityEngine;

public class RotateCircle : MonoBehaviour
{

    public float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Rotate(0f,0f,speed*Time.deltaTime);
        transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
