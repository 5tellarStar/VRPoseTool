using UnityEngine;

public class PlayerHandPhysics : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Transform controller;
    [SerializeField] private float strength = 1.0f;
    [SerializeField] private float speed = 1.0f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.rotation = controller.rotation;

        Vector3 delta = controller.position - transform.position;

        rb.linearVelocity = delta * speed;

        playerMovement.AddVelocity(strength * Time.deltaTime * -delta);
    }
}
