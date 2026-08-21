using Unity.VisualScripting;
using UnityEngine;

public class PoseTutorial : MonoBehaviour
{
    [SerializeField] private PoseListener listener;
    public PoseData pose;
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;
    [SerializeField] private SkinnedMeshRenderer[] renderers;

    [SerializeField] private Quaternion rRotOffset;
    [SerializeField] private Quaternion lRotOffset;

    private Material[] materials;

    private bool isPosing;

    private void Start()
    {
        if (pose == null) pose = new PoseData();

        materials = new Material[renderers.Length];

        for (int i = 0; i < renderers.Length; i++)
        {
            materials[i] = renderers[i].material;
        }

        listener.RegisterPose(pose, OnPose);
    }

    void Update()
    {
        if (!isPosing)
        {
            foreach (var material in materials)
            {
                material.color = Color.red;
            }
        }
        isPosing = false;

        ShowPose();
    }

    private void ShowPose()
    {
        if (pose == null) return;

        head.eulerAngles = new Vector3(0.0f, head.eulerAngles.y, 0.0f);

        rHand.position = head.TransformPoint(pose.rHandPostion);
        lHand.position = head.TransformPoint(pose.lHandPostion);

        rHand.rotation = head.rotation * pose.rHandRotation * rRotOffset;
        lHand.rotation = head.rotation * pose.lHandRotation * lRotOffset;
    }

    public void OnPose()
    {
        foreach (var material in materials)
        {
            material.color = Color.green;
        }
        isPosing = true;
    }
}
