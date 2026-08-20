using System;
using System.Collections.Generic;
using UnityEngine;

public class PoseListener : MonoBehaviour
{
    [SerializeField] private Transform head;
    [SerializeField] private Transform rHand;
    [SerializeField] private Transform lHand;

    [SerializeField] private float positionMargin;
    [SerializeField] private float rotationMargin;

    private float sqrPositionMarging;
    private float halfRadRotationMarging;

    private List<(PoseData, Action)> registeredPoses = new();

    private void Awake()
    {
        sqrPositionMarging = positionMargin * positionMargin;
        halfRadRotationMarging = Mathf.Deg2Rad * rotationMargin / 2f;
    }

    public void RegisterPose(PoseData data, Action action)
    {
        registeredPoses.Add((data, action));
    }

    void Update()
    {
        head.eulerAngles = new Vector3(0.0f, head.eulerAngles.y, 0.0f);

        foreach (var pose in registeredPoses)
        {
            if (!CheckPose(pose.Item1)) continue;
            pose.Item2?.Invoke();
        } 
    }

    private bool CheckPose(PoseData data)
    {
        if (!CheckHand(rHand, data.rHandPostion, data.rHandRotation)) return false;
        if (!CheckHand(lHand, data.lHandPostion, data.lHandRotation)) return false;
        return true;
    }

    private bool CheckHand(Transform hand, Vector3 pos, Quaternion rot)
    {
        if ((hand.position - head.TransformPoint(pos)).sqrMagnitude > sqrPositionMarging) return false;
        if (Mathf.Acos(Mathf.Abs(Quaternion.Dot(hand.rotation, head.rotation * rot))) > halfRadRotationMarging) return false;
        return true;
    }
}
