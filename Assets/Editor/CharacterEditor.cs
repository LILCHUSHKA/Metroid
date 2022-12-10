using UnityEngine;
using UnityEditor;

public class CharacterEditor : EditorWindow
{
    static CharacterEditor characterEditorWindow;
    private static Character characteristicsData;
    SerializedProperty _items;

    public static void OpenCharacterWindow(Character characteristics)
    {
        characterEditorWindow = GetWindow<CharacterEditor>("Character Designer");

        characterEditorWindow.minSize = new Vector2(650, 600);
        characterEditorWindow.maxSize = new Vector2(Screen.width, Screen.height);
        characteristicsData = characteristics;
    }

    Rect characterSection;
    Rect inventorySection;

    Texture2D characterSectionTexture;
    Texture2D inventorySectionTexture;

    private void OnGUI()
    {
        _items = EditCharacteristics.inventoryProperty;

        DrawSections();

        #region Characteristics settings
        GUILayout.BeginArea(characterSection);
        GUILayout.Label("Характеристики", GUILayout.Height(50));

        GUILayout.BeginHorizontal();
        characteristicsData.characterType = (Character.CharacterTypes)EditorGUILayout.EnumPopup
            ("Тип персонажа", characteristicsData.characterType, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();

        switch (characteristicsData.characterType)
        {
            case Character.CharacterTypes.NPC:
                if (GUILayout.Button("Открыть редактор диалога")) DialogEditor.OpenDialogWindow();
                DrawFields();
                break;
            case Character.CharacterTypes.enemy:
            case Character.CharacterTypes.hero:
                DrawFields();
                break;

        }
        GUILayout.EndArea();
        #endregion

        #region Inventory settings

        GUILayout.BeginArea(inventorySection);
        GUILayout.Label("Инвентарь");

        GUILayout.BeginHorizontal();
        GUILayout.Label("Предметы в инвентаре");
        EditorGUILayout.PropertyField(_items, GUILayout.Width(characterSection.width - 200));
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

        #endregion
    }

    void DrawFields()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Имя");
        characteristicsData.name = EditorGUILayout.TextField(characteristicsData.name, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Максимальный уровень здоровья");
        characteristicsData.maxHealth = EditorGUILayout.IntField(characteristicsData.maxHealth, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Здоровье");
        characteristicsData.health = EditorGUILayout.IntField(characteristicsData.health, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Наносимый урон");
        characteristicsData.damageValue = EditorGUILayout.IntField(characteristicsData.damageValue, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();

        GUILayout.Label("Резисты", GUILayout.Height(30));

        GUILayout.BeginHorizontal();
        GUILayout.Label("Сопротивление к физическим ударам (%)");
        characteristicsData.physicResist = EditorGUILayout.IntField(characteristicsData.physicResist, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Сопротивление к магии (%)");
        characteristicsData.magicResist = EditorGUILayout.IntField(characteristicsData.magicResist, GUILayout.Width(characterSection.width - 100));
        GUILayout.EndHorizontal();
    }

    void DrawSections()
    {
        #region Characteristics section settings
        characterSectionTexture = new Texture2D(1, 1);

        characterSection.x = 0;
        characterSection.y = 0;
        characterSection.width = characterEditorWindow.minSize.x;

        switch (characteristicsData.characterType)
        {
            case Character.CharacterTypes.enemy:
            case Character.CharacterTypes.hero:
                characterSection.height = 240;
                break;
            case Character.CharacterTypes.NPC:
                characterSection.height = 260;
                break;
        }

        characterSectionTexture.SetPixel(0, 0, new Color(100f / 255f, 59f / 255f, 59f / 255f, 1));
        characterSectionTexture.Apply();
        #endregion

        #region Inventory section settings
        inventorySectionTexture = new Texture2D(1, 1);

        inventorySection.x = 0;
        inventorySection.y = characterSection.height;
        inventorySection.width = characterEditorWindow.minSize.x;
        inventorySection.height = 130;

        if (characteristicsData.inventory.Count != 0) inventorySection.height += characteristicsData.inventory.Count * 20;

        inventorySectionTexture.SetPixel(0, 0, new Color(62f / 255f, 77f / 255f, 60f / 255f, 1));
        inventorySectionTexture.Apply();
        #endregion

        GUI.DrawTexture(inventorySection, inventorySectionTexture);
        GUI.DrawTexture(characterSection, characterSectionTexture);
    }
}

[CanEditMultipleObjects]
[CustomEditor(typeof(Character))]
public class EditCharacteristics : Editor
{
    public static SerializedProperty inventoryProperty;
    public static SerializedProperty characterTypeProperty;

    public override void OnInspectorGUI()
    {
        inventoryProperty = serializedObject.FindProperty("inventory");
        characterTypeProperty = serializedObject.FindProperty("CharacterTypes");

        if (GUILayout.Button("Открыть редактор персонажа", GUILayout.Height(35))) CharacterEditor.OpenCharacterWindow((Character)target);
    }
}