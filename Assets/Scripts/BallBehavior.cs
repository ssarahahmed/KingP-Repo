using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minX = -8.048f;
    public float minY = -4.16f;
    public float maxX = 7.8f;
    public float maxY = 4.34f;

    public float minSpeed = 1f;
    public float maxSpeed = 5f;

    public GameObject target; // Pin
    public bool launching = false;
    public float timeLastLaunch;
    public float launchDuration = 3f; // Example duration
    public int secondsToMaxSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (target != null)
        {
            launching = true; // Start following the pin immediately
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
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
        }
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

    public void Launch()
    {
        if (!launching)
        {
            launching = true;
            timeLastLaunch = Time.time;
        }
    }
}
