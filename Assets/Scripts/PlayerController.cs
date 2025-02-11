/* using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    // capture the input
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            jumpRequested = true;
        }
        
    }

    void FixedUpdate()
    // Perform jump
    {
        if (jumpRequested) {
            Rigidbody2D body = GetComponent<Rigidbody2D>();
            body.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            jumpRequested = false;
        }
    }
}
*/
