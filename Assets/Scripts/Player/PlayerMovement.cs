using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private InputActionProperty movementAction;
    [SerializeField] private float accel = 20f;
    [SerializeField] private float friction = 2f; 
    [SerializeField] private float gravity = -9.82f;

    private Vector3 addedVelocity = Vector3.zero;
    private Vector3 lastVelocity = Vector3.zero;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 newVelocity = characterController.velocity;

        if ((newVelocity - lastVelocity).sqrMagnitude > 2)
            newVelocity = lastVelocity;

        newVelocity += addedVelocity;
        addedVelocity = Vector3.zero;

        if(characterController.isGrounded)
        {
            Vector2 movementInput = movementAction.action.ReadValue<Vector2>();
        
            newVelocity += accel * Time.deltaTime * new Vector3(movementInput.x, 0, movementInput.y);
            newVelocity -= newVelocity * Mathf.Clamp01(friction * Time.deltaTime);
        }
        else
        {
            newVelocity += new Vector3(0, gravity, 0) * Time.deltaTime;
        }

        characterController.Move(newVelocity * Time.deltaTime);
        lastVelocity = newVelocity;
    }

    public void AddVelocity(Vector3 velocity)
    {
        addedVelocity += velocity;
    }
}
