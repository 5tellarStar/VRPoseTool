using UnityEngine;

public class PoseViewer : MonoBehaviour
{
    public PoseData pose; 
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;

    void Update()
    {
        rHand.position = head.TransformPoint(pose.rHandPostion);
        lHand.position = head.TransformPoint(pose.lHandPostion);

        rHand.rotation = head.rotation * pose.rHandRotation ;
        lHand.rotation = head.rotation * pose.lHandRotation;
    }
}
