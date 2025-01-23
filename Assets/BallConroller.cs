using UnityEngine;

public class BallConroller : MonoBehaviour
{
    public Rigidbody sphereRigidbody;
    public float ballSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            inputVector += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputVector += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputVector += Vector2.right;
        }

        Vector3 inputXZPlane = new Vector3(inputVector.x, 0, inputVector.y);
        
        sphereRigidbody.AddForce(inputXZPlane * ballSpeed);

        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(sphereRigidbody.transform.position, Vector3.down, 0.6f))
        {
            Vector3 jump = new Vector3(0, 5, 0);
            sphereRigidbody.AddForce(jump);
        }

        if (sphereRigidbody.transform.position.y < -10)
        {
            sphereRigidbody.transform.position = new Vector3(0, 1, 0);
            sphereRigidbody.linearVelocity = Vector3.zero;
        }
    }
}
