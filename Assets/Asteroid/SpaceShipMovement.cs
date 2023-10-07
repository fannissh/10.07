using UnityEngine;

class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] float angularSpeed = 180f;
    [SerializeField] float maxspeed = 2f;
    [SerializeField] float acceleration = 4;
    [SerializeField] float drag = 0.5f;
    Vector3 velocity;

    void FixedUpdate()
    {
        
        // Gyorsul�s
        float movementInput = Input.GetAxisRaw("Vertical");
        if (movementInput > 0)
        {
            Vector3 globalDirection = transform.up * movementInput;             
            velocity += globalDirection * acceleration * Time.fixedDeltaTime;             
            velocity = Vector3.ClampMagnitude(velocity, maxspeed);
        }

        //K�zegellen�ll�s
        Vector3 dragAcceleration = -velocity * drag;
        velocity += dragAcceleration * Time.fixedDeltaTime;


    }
    void Update()
    {
        // Fordul�s
        float rotationInput = -Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, rotationInput * angularSpeed * Time.deltaTime);

        // Mozg�s
        transform.position += velocity * Time.deltaTime;
    }

}
