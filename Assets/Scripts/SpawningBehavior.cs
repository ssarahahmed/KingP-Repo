using UnityEngine;

public class SpawningBehavior : MonoBehaviour
{
    public GameObject[] ballVariants;
    public GameObject targetObject;
    GameObject newObject;
    public float startTime;
    public float spawnRatio = 1.0f;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float minSpawn;
    public float maxSpawn;

    public int maxBalls = 2;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start(){
        spawnBall();
        spawnRatio = Random.Range(minSpawn, maxSpawn);
    }



    void spawnBall()
    {
        GameObject[] activeBalls = GameObject.FindGameObjectsWithTag("Ball");
        int activeBallCount = activeBalls.Length;

        if (activeBallCount < maxBalls) {
            if ( ballVariants.Length > 0) {
                int slection = Random.Range(0, ballvariants.Length);
                newObject = Instantiate(ballvariants[selection], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
        

        //int numVariants = ballVariants.Length;
        //if (numVariants > 0) {
            //int selection = Random.Range(0, numVariants);
           // newObject = Instantiate(ballVariants[selection], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            BallBehavior ballBehavior = newObject.GetComponent<BallBehavior>();
            ballBehavior.setBounds(minX, maxX, minY, maxY);
            ballBehavior.setTarget(targetObject);
            ballBehavior.initialPosition();
    }
        }
        
        startTime = Time.time;
        spawnRatio = Random.Range(minSpawn, maxSpawn);
    }

    

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
            if(timeElapsed > spawnRatio) {
                spawnBall();
            }
        }
}
    

