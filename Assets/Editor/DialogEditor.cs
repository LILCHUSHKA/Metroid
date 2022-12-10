using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Dialog))]
public class EditDialog : Editor
{
    public static SerializedProperty dialogProperty;

    public override void OnInspectorGUI()
    {
        dialogProperty = serializedObject.FindProperty("dialog");
    }
}

public class DialogEditor : EditorWindow
{
    Texture2D dialogSectionTexture;
    Rect dialogSection;

    public static void OpenDialogWindow()
    {
        DialogEditor DiadlogEditorWindow = GetWindow<DialogEditor>("Dialog Designer");

        DiadlogEditorWindow.minSize = new Vector2(650, 300);
        DiadlogEditorWindow.maxSize = new Vector2(650, 1000);
    }

    private void OnGUI()
    {
        dialogSectionTexture = new Texture2D(1, 1);

        dialogSection.x = 0;
        dialogSection.y = 0;
        dialogSection.width = Screen.width;
        dialogSection.height = Screen.height;

        dialogSectionTexture.SetPixel(0, 0, new Color(110f / 255f, 100f / 255f, 120f / 255f, 1));
        dialogSectionTexture.Apply();

        GUI.DrawTexture(dialogSection, dialogSectionTexture);

        GUILayout.BeginArea(dialogSection);

        EditorGUILayout.PropertyField(EditDialog.dialogProperty);

        GUILayout.EndArea();
    }
}