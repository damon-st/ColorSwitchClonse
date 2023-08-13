
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public float jumpForce = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;


    public GameObject particles;
    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity=Vector2.up *jumpForce;
            AudioManager.PlayTouchSoung();
        }
    }

    private void FixedUpdate()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChanged")
        {
            SetRandomColor();
            Destroy(collision.gameObject);
            return;
        }

        if(collision.tag == "Estrella")
        {
            collision.gameObject.SendMessage("OnPlayStart");
            return;
        }
        if(collision.tag == "Ignore"){
            return;
        }

        if (collision.tag != currentColor)
        {
            ///TODO: GAME OVER
            AudioManager.PlayDestroySoung();
            rb.simulated = false;
            sr.enabled = false;
            particles.SetActive(true);
            Invoke("RestarLeve", 1.0f);
        }
    }

    private void RestarLeve()
    {
        MainCtrl.GoToGameOver();

    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
                case 1:
                currentColor = "Yellow";
                sr.color= colorYellow;
                break; 
                case 2:
                currentColor = "Magento";
                sr.color= colorMagenta;
                break;
                case 3:
                currentColor = "Pink";
                sr.color= colorPink;
                break;
        }
    }
}
