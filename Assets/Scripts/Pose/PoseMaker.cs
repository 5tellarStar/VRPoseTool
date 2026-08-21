using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PoseMaker : MonoBehaviour
{
    private PoseData pose = null;

    [SerializeField] private UIKeyboard keyboard;
    [SerializeField] private PoseViewer poseViewer;
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;

    [SerializeField] private InputActionProperty poseButton;

    void Update()
    {
        if (poseButton.action.WasPressedThisFrame())
        {
            head.eulerAngles = new Vector3(0.0f, head.eulerAngles.y, 0.0f);

            if (pose == null) pose = ScriptableObject.CreateInstance<PoseData>();

            pose.rHandPostion = head.InverseTransformPoint(rHand.position);
            pose.lHandPostion = head.InverseTransformPoint(lHand.position);

            pose.rHandRotation = Quaternion.Inverse(head.rotation) * rHand.rotation;
            pose.lHandRotation = Quaternion.Inverse(head.rotation) * lHand.rotation;

            poseViewer.pose = pose;
        }
    }

    public void SavePose()
    {
        if(pose == null) return;

        string name = keyboard.writtenText != "" ? keyboard.writtenText : "New Pose";

        if (AssetDatabase.AssetPathExists("Assets/Poses/" + name + ".asset"))
        {
            int num = 0;
            while (AssetDatabase.AssetPathExists("Assets/Poses/" + name + " " + num.ToString() + ".asset")) num++;
            AssetDatabase.CreateAsset(pose, "Assets/Poses/" + name + " " + num.ToString() + ".asset");
        }
        else
        {
            AssetDatabase.CreateAsset(pose, "Assets/Poses/" + name + ".asset");
        }

        PoseData oldPose = pose;

        pose = ScriptableObject.CreateInstance<PoseData>();

        pose.rHandPostion = oldPose.rHandPostion;
        pose.lHandPostion = oldPose.lHandPostion;
        pose.rHandRotation = oldPose.rHandRotation;
        pose.lHandRotation = oldPose.lHandRotation;
    }
}
