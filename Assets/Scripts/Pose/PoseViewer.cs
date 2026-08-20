using UnityEngine;

public class PoseViewer : MonoBehaviour
{
    [SerializeField] private PoseData pose; 
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;

    void Update()
    {
        rHand.position = head.TransformPoint(pose.rHandPostion);
        lHand.position = head.TransformPoint(pose.lHandPostion);

        rHand.rotation = pose.rHandRotation;
        lHand.rotation = pose.lHandRotation;
    }
}
