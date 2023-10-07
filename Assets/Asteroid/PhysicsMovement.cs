using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] float angularSpeed = 180f;
    [SerializeField] float maxspeed = 2f;
    [SerializeField] float acceleration = 4;
    [SerializeField, HideInInspector] Rigidbody2D rigidBody2D;

    void OnValidate()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Gyorsulás
        float movementInput = Input.GetAxisRaw("Vertical");
        if (movementInput > 0)
        {
            Vector2 globalDirection = transform.up * movementInput;
            rigidBody2D.velocity += globalDirection * acceleration * Time.fixedDeltaTime;
            rigidBody2D.velocity = Vector2.ClampMagnitude(rigidBody2D.velocity, maxspeed);
        }
    }
    void Update()
    {
        // Fordulás
        float rotationInput = -Input.GetAxisRaw("Horizontal");
        transform.Rotate(0, 0, rotationInput * angularSpeed * Time.deltaTime);
        rigidBody2D.angularVelocity = 0;

        
    }
}
