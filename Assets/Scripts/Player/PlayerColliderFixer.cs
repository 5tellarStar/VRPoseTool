using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerColliderFixer : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private Transform head;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Vector3 delta = head.position - transform.position;
        
        characterController.center = new Vector3(delta.x, delta.y / 2f, delta.z);
        characterController.height = delta.y;
    }
}
