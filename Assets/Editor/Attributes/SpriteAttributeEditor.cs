using Data.Inventory.Attributes;
using UnityEditor;
using UnityEngine;

namespace Editor.Attributes
{
    [CustomPropertyDrawer(typeof(SerializedSpriteAttribute))]
    public class SpriteAttributeEditor : PropertyDrawer
    {
        private const float Spacing = 6f;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (property.propertyType != SerializedPropertyType.ObjectReference)
            {
                EditorGUI.PropertyField(position, property, label);
                return;
            }

            var size = GetPreviewSize();
            var previewRect = new Rect(position.xMax - size, position.y, size, size);
            var fieldRect = new Rect
                            (
                                position.x,
                                position.y + Mathf.Max(0f, (size - EditorGUIUtility.singleLineHeight) * 0.5f),
                                Mathf.Max(0f, position.width - size - Spacing),
                                EditorGUIUtility.singleLineHeight
                            );

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            EditorGUI.showMixedValue = property.hasMultipleDifferentValues;
            
            var sprite = EditorGUI.ObjectField(fieldRect, label, property.objectReferenceValue, typeof(Sprite), false) as Sprite;
            
            EditorGUI.showMixedValue = false;

            if (EditorGUI.EndChangeCheck())
            {
                property.objectReferenceValue = sprite;
            }

            DrawSpritePreview(previewRect, property.objectReferenceValue as Sprite, property);
            HandleDragAndDrop(position, property);

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) => Mathf.Max(EditorGUIUtility.singleLineHeight, GetPreviewSize()) + EditorGUIUtility.standardVerticalSpacing;

        private float GetPreviewSize() => attribute is SerializedSpriteAttribute spriteAttribute ? spriteAttribute.Size : 64f;

        private void DrawSpritePreview(Rect previewRect, Sprite sprite, SerializedProperty property)
        {
            GUI.Box(previewRect, GUIContent.none, EditorStyles.helpBox);

            if (sprite != null)
            {
                var texture = sprite.texture;
                if (texture != null)
                {
                    var textureRect = sprite.textureRect;
                    var textureCoords = new Rect(
                        textureRect.x / texture.width,
                        textureRect.y / texture.height,
                        textureRect.width / texture.width,
                        textureRect.height / texture.height);

                    GUI.DrawTextureWithTexCoords(previewRect, texture, textureCoords, true);
                }
            }
            else
            {
                var style = new GUIStyle(EditorStyles.miniLabel) { alignment = TextAnchor.MiddleCenter };
                GUI.Label(previewRect, "None", style);
            }

            if (GUI.Button(previewRect, GUIContent.none, GUIStyle.none))
            {
                EditorGUIUtility.ShowObjectPicker<Sprite>(sprite, false, string.Empty, GetControlId(property));
            }

            if (Event.current.commandName == "ObjectSelectorUpdated" &&
                EditorGUIUtility.GetObjectPickerControlID() == GetControlId(property))
            {
                property.objectReferenceValue = EditorGUIUtility.GetObjectPickerObject() as Sprite;
                property.serializedObject.ApplyModifiedProperties();
            }
        }

        private static int GetControlId(SerializedProperty property)
        {
            return property.propertyPath.GetHashCode();
        }

        private static void HandleDragAndDrop(Rect dropArea, SerializedProperty property)
        {
            var currentEvent = Event.current;
            if (!dropArea.Contains(currentEvent.mousePosition))
            {
                return;
            }

            switch (currentEvent.type)
            {
                case EventType.DragUpdated:
                case EventType.DragPerform:
                    var sprite = GetDraggedSprite();
                    DragAndDrop.visualMode = sprite != null ? DragAndDropVisualMode.Copy : DragAndDropVisualMode.Rejected;

                    if (currentEvent.type == EventType.DragPerform && sprite != null)
                    {
                        DragAndDrop.AcceptDrag();
                        property.objectReferenceValue = sprite;
                        property.serializedObject.ApplyModifiedProperties();
                    }

                    currentEvent.Use();
                    break;
            }
        }

        private static Sprite GetDraggedSprite()
        {
            foreach (var draggedObject in DragAndDrop.objectReferences)
            {
                if (draggedObject is Sprite sprite)
                {
                    return sprite;
                }

                if (draggedObject is Texture2D texture)
                {
                    var path = AssetDatabase.GetAssetPath(texture);
                    if (!string.IsNullOrEmpty(path))
                    {
                        var sprites = AssetDatabase.LoadAllAssetsAtPath(path);
                        foreach (var asset in sprites)
                        {
                            if (asset is Sprite textureSprite)
                            {
                                return textureSprite;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}