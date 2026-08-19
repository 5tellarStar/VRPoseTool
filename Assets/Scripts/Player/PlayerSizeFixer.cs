using UnityEngine;
using UnityEngine.Assemblies;
using UnityEngine.InputSystem;

public class PlayerSizeFixer : MonoBehaviour
{
    [SerializeField] private InputActionProperty FixButtonAction;
    [SerializeField] private Transform head;
    [SerializeField] private Transform rightController;
    [SerializeField] private Transform leftController;
    [SerializeField] private Transform controllerScale;
    [SerializeField] private float timeToFix = 1f;
    [SerializeField] private float wantedArmSpan = 1f;
    [SerializeField] private float wantedShoulderHeight = 1f;
    [SerializeField] private float wantedHeight = 1f;

    private float timeHeld = 0f;
    private bool buttonHeld = false;
    private float controllerOffset = 0f;

    // Update is called once per frame
    void Update()
    {
        if (FixButtonAction.action.WasPressedThisFrame())
        {
            buttonHeld = true;
            timeHeld = 0f;
        }

        if (FixButtonAction.action.WasReleasedThisFrame()) buttonHeld = false;

        if (buttonHeld)
        {
            timeHeld += Time.deltaTime;

            if (timeHeld > timeToFix)
            {
                buttonHeld = false;

                float currentArmSpan = (leftController.transform.position - rightController.transform.position).magnitude;
                controllerScale.transform.localScale *= wantedArmSpan / currentArmSpan;

                float currentShoulderHeight = (rightController.transform.position.y + leftController.transform.position.y) / 2;
                controllerOffset = controllerScale.transform.position.y + wantedShoulderHeight - currentShoulderHeight;
                controllerScale.transform.localPosition = new Vector3(0, controllerOffset, 0);
                
                float currentHeight = head.transform.position.y - transform.position.y;
                transform.localScale *= wantedHeight / currentHeight;
            }
        }

        controllerScale.transform.localPosition = new Vector3(0, Mathf.Lerp(0, controllerOffset, (head.transform.position.y - transform.position.y) / wantedHeight), 0);
    }
}
