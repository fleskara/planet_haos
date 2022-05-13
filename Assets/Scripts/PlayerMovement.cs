using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] float speed = 6f;
	[SerializeField] float rotationSpeed = 1500f;
    [SerializeField] float jumpForce = 1000f;
    [SerializeField] Transform groundDetector;
    [SerializeField] LayerMask groundMask;

    private Rigidbody rigidbody;
    private Vector2 inputVector;
    private ObjectGravity gravityBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
        gravityBody = transform.GetComponent<ObjectGravity>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        bool isGrounded = Physics.CheckSphere(groundDetector.position, 0.1f, groundMask);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(-gravityBody.getGravityDirectionVector() * jumpForce, ForceMode.Impulse);
        }
        
    }

    void FixedUpdate()
    {
        Vector3 direction = transform.forward * inputVector.y;
        rigidbody.MovePosition(rigidbody.position + direction * (speed * Time.fixedDeltaTime));
        
        Quaternion yRotation = Quaternion.Euler(0f, inputVector.x * (rotationSpeed * Time.fixedDeltaTime), 0f);
        Quaternion newRotation = Quaternion.Slerp(rigidbody.rotation, rigidbody.rotation * yRotation, Time.fixedDeltaTime * 3f);
        rigidbody.MoveRotation(newRotation);
    }
}
