using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "PoseData", menuName = "Scriptable Objects/PoseData")]
public class PoseData : ScriptableObject
{
    public Vector3 rHandPostion;
    public Quaternion rHandRotation;

    public Vector3 lHandPostion;
    public Quaternion lHandRotation;
}

[CustomEditor(typeof(PoseData))]
public class PoseDataEditor : Editor
{
    private PreviewRenderUtility previewUtility;
    private GameObject previewObject;

    public override bool HasPreviewGUI()
    {
        return true;
    }

    private void OnEnable()
    {
        previewUtility = new PreviewRenderUtility();

        previewObject = Instantiate((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Pose Viewer.prefab", typeof(GameObject)));
        previewObject.GetComponent<PoseViewer>().pose = (PoseData)target;
        previewObject.GetComponent<PreviewPoseUpdater>().PreviewStart();
        previewUtility.AddSingleGO(previewObject);

        previewUtility.camera.transform.position = new Vector3(0, 0.9f, 7);
        previewUtility.camera.transform.LookAt(new Vector3(0, 0.9f, 0));
    }

    private void OnDisable()
    {
        if (previewUtility != null)
        {
            previewUtility.Cleanup();
            previewUtility = null;
        }

        if (previewObject != null)
        {
            DestroyImmediate(previewObject);
        }
    }

    public override void OnPreviewGUI(Rect rect, GUIStyle background)
    {
        previewUtility.BeginPreview(rect, background);

        previewObject.GetComponent<PoseViewer>().ShowPose();
        previewUtility.camera.Render();

        Texture result = previewUtility.EndPreview();

        GUI.DrawTexture(rect, result, ScaleMode.StretchToFill, false);
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck();

        DrawDefaultInspector();

        if (EditorGUI.EndChangeCheck())
        {
            serializedObject.ApplyModifiedProperties();

            ShowPose();

            Repaint();
        }
    }
    private void ShowPose()
    {
        if (previewObject == null) return;

        previewObject.GetComponent<PreviewPoseUpdater>().PreviewUpdate();
    }
}
