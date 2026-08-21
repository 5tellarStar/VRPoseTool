using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempPoseMaker : MonoBehaviour
{
    [SerializeField] private PoseViewer viewer;
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;

    [SerializeField] private InputActionProperty saveButton;

    void Update()
    {
        if(saveButton.action.WasPressedThisFrame())
        {
            head.eulerAngles = new Vector3(0.0f, head.eulerAngles.y, 0.0f);

            PoseData pose = new PoseData();

            ((PoseData)pose).rHandPostion = head.InverseTransformPoint(rHand.position);
            ((PoseData)pose).lHandPostion = head.InverseTransformPoint(lHand.position);

            ((PoseData)pose).rHandRotation = Quaternion.Inverse(head.rotation) * rHand.rotation;
            ((PoseData)pose).lHandRotation = Quaternion.Inverse(head.rotation) * lHand.rotation;

            AssetDatabase.CreateAsset(pose, "Assets/newPose.asset");

            if(viewer != null)
            {
                viewer.pose = (PoseData)pose;
            }
        }
    }
}
