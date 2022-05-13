using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGravity : MonoBehaviour
{
    [SerializeField] float gravityForce = 1500f;
    [SerializeField] Vector3 planetCenter;

    private Rigidbody rigidbody;
    private Vector3 gravityDirection;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        gravityDirection = (planetCenter -transform.position).normalized;
        rigidbody.AddForce(gravityDirection * (gravityForce * Time.fixedDeltaTime), ForceMode.Acceleration);

        Quaternion rotateUp = Quaternion.FromToRotation(transform.up, -gravityDirection);
        //Quaternion newRotation = Quaternion.Slerp(rigidbody.rotation, rotateUp * rigidbody.rotation, Time.fixedDeltaTime * 5f);
        Quaternion newRotation = rotateUp * rigidbody.rotation;
        rigidbody.MoveRotation(newRotation);
    }

    public Vector3 getGravityDirectionVector()
    {
        return gravityDirection;
    }
}
