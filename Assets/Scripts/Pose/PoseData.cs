using UnityEngine;

[CreateAssetMenu(fileName = "PoseData", menuName = "Scriptable Objects/PoseData")]
public class PoseData : ScriptableObject
{
    public Vector3 rHandPostion;
    public Quaternion rHandRotation;

    public Vector3 lHandPostion;
    public Quaternion lHandRotation;
}
