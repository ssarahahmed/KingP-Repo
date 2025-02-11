using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    Rigidbody2D body;
    public bool rerouting;
    public float minX = -8.048f;
    public float minY = -4.16f;
    public float maxX = 7.8f;
    public float maxY = 4.34f;

    public float minSpeed = 1f;
    public float maxSpeed = 5f;
    public Vector2 targetPosition;

    public GameObject target; // Pin
    public bool launching = false;
    public float timeLastLaunch;
    public float launchDuration;
    public float timeLaunchStart;
    public float minLaunchSpeed;
    public float maxLaunchSpeed;
    public float cooldown;

    public int secondsToMaxSpeed;

public void InitialPosition(){
    body = GetComponent<Rigidbody2D>();
    body.position = GetRandomPosition();
    targetPosition = GetRandomPosition();
    launching = false;
    rerouting = false;
}
public void Reroute(Collision2D collision) {
    GameObject otherBall = collision.gameObject;
    if (rerouting == true) {
        otherBall.GetComponent<BallBehavior>().rerouting = false;
        Rigidbody2D ballBody = otherBall.GetComponent<Rigidbody2D>();
        Vector2 contact = collision.GetContact(0).normal;
        targetPosition = Vector2.Reflect(targetPosition, contact).normalized;
        launching = false;
        float separationDistance = 0.1f;
        ballBody.position += contact * separationDistance;
    }
        else {
            rerouting = true;
        }
}
    // Start is called before the first frame update
    void Start()
    {
        //if (target != null)
       // {
      //      launching = true; // Start following the pin immediately
       // }
       targetPosition = GetRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (target == null)
            return; // Avoid errors if no target is set

        Vector2 currentPosition = transform.position;
        float difficulty = GetDifficultyPercentage();
        float currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, difficulty) * Time.deltaTime;

        if (launching)
        {
            // Continuously update targetPosition to follow the pin
            Vector2 targetPosition = target.transform.position;
            transform.position = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
        }
        else
        {
            // Move randomly when not launching
            Vector2 randomTarget = GetRandomPosition();
            transform.position = Vector2.MoveTowards(currentPosition, randomTarget, currentSpeed);
        }*/
    }

    private float GetDifficultyPercentage()
    {
        return Mathf.Clamp01(Time.time / secondsToMaxSpeed);
    }

    private Vector2 GetRandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        return new Vector2(randomX, randomY);
    }

    
    public void StartCooldown()
    {
        launching = false;
        timeLastLaunch = Time.time;
    }

    public bool onCooldown() 
    {
        bool onCooldown = true;
        float timeSinceLastLaunch = (Time.time - timeLastLaunch);
        if (timeSinceLastLaunch > cooldown) {
            onCooldown = false;
        }
        return onCooldown;
    }

    public void launch()
    {
        Rigidbody2D targetBody = target.GetComponent<Rigidbody2D>();
        targetPosition = targetBody.position;

        if (!launching)
        {
            launching = true;
            timeLaunchStart = Time.time;
            timeLastLaunch = Time.time;
        }
    }

        void FixedUpdate()
        {
            body = GetComponent<Rigidbody2D>();

            Vector2 currentPosition = body.position;
            float currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, GetDifficultyPercentage()) * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            body.MovePosition(newPosition);
            if (onCooldown() == false) {
                if (launching == true) {
                    float currentLaunchTime = Time.time - timeLaunchStart;
                    if (currentLaunchTime > launchDuration) {
                        StartCooldown();
                    }
                } else{
                    launch();
                }
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision) {
            string collided = collision.gameObject.tag;
            Debug.Log("Collided with " + collided);
            if(collided == "Wall") {
                targetPosition = GetRandomPosition();
            }
            if(collided == "Pin") {
                Reroute(collision);
            }
        }
}

