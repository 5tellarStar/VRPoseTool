using UnityEngine;

public class PoseViewer : MonoBehaviour
{
    public PoseData pose; 
    [SerializeField] private PoseData defaultPose;
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;
    [SerializeField] private Transform rFoot;
    [SerializeField] private Transform lFoot;

    void Update()
    {
        ShowPose();
    }

    public void ShowPose()
    {
        if (pose == null) pose = defaultPose;

        rFoot.localPosition = new Vector3(0.08207826f, -1f, -0.02742776f);
        rFoot.localEulerAngles = new Vector3(-50.821f, 0, -180);
        lFoot.localPosition = new Vector3(-0.08207826f, -1f, -0.02742776f);
        lFoot.localEulerAngles = new Vector3(-50.821f, 0, -180);

        rHand.position = head.TransformPoint(pose.rHandPostion);
        lHand.position = head.TransformPoint(pose.lHandPostion);

        rHand.rotation = head.rotation * pose.rHandRotation;
        lHand.rotation = head.rotation * pose.lHandRotation;
    }
}
