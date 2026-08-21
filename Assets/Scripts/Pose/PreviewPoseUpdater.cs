using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PreviewPoseUpdater : MonoBehaviour
{
    [SerializeField] private PoseViewer poseViewer;
    [SerializeField] private IKTargetFollowVRRig iKTargetFollow;
    [SerializeField] private RigBuilder rigBuilder;

    public void PreviewStart()
    {
        rigBuilder.Build();
        poseViewer.ShowPose();
        iKTargetFollow.turnSmoothness = 1f;
        iKTargetFollow.LateUpdate();
        rigBuilder.graph.Evaluate();
    }

    public void PreviewUpdate()
    {
        poseViewer.ShowPose();
        iKTargetFollow.LateUpdate();
        rigBuilder.graph.Evaluate();
    }
}
