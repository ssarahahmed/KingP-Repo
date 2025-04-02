// written by sarah ahmed
using UnityEngine;

public class PinBehavior : MonoBehaviour
{
    public float start;
    public float speed;
    public float baseSpeed = 2.0f;
    public float dashSpeed = 8.0f;
    public float dashDuration = 0.3f;
    public bool dashing;
    public Vector2 newPosition;
    public Vector3 mousePosG;
    public float cooldownRate = 1.0f;
    public float endLastDash;
    public float cooldown = 0.0f;
    Camera cam;
   

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        newPosition = transform.position;
         dashing = false;
    if(Input.GetMouseButtonDown(0)) {
    
    }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        string collided = collision.gameObject.tag;
        Debug.Log("Collided with " + collided);
        if (collided == "Ball" || collided == "Wall") {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver"); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition = Vector2.MoveTowards(transform.position, mousePosG, speed * Time.deltaTime);
        transform.position = newPosition;
        Dash();
        
    }

    private void Dash() {
        if(dashing == true) {
            float currenttime = Time.time;
            float timeDashing = currenttime - start;
            if(timeDashing > dashDuration) {
                dashing = false;
                speed = baseSpeed;
                cooldown = cooldownRate;
            }
        }
        else {
            cooldown = cooldown - Time.deltaTime;
            if (cooldown < 0.0f) {
                cooldown = 0.0f;
            }
            if (cooldown == 0.0 && Input.GetMouseButtonDown(0)) {
                dashing = true;
                speed = dashSpeed;
                start = Time.time;
            }
        }
    }
}