using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;
using Sirenix.Utilities.Editor;

namespace Brent.UI
{
    [CustomEditor(typeof(UIButton), true)]
    public class UIButtonEditor : ButtonEditor
    {
        SerializedProperty _buttonClickEnum;
        SerializedProperty _itemId;
        SerializedProperty _clickThreshold;
        SerializedProperty _doubleClickThreshold;
        SerializedProperty _pressThreshold;

        protected override void OnEnable()
        {
            base.OnEnable();

            _buttonClickEnum = serializedObject.FindProperty("buttonClickEnum");
            _itemId = serializedObject.FindProperty("itemId");
            _clickThreshold = serializedObject.FindProperty("clickThreshold");
            _doubleClickThreshold = serializedObject.FindProperty("doubleClickThreshold");
            _pressThreshold = serializedObject.FindProperty("pressThreshold");

        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var _uiButton = (UIButton)target;


            SirenixEditorGUI.BeginHorizontalToolbar(28, 4);
            {
                bool isSingle = _uiButton.buttonClickEnum.HasFlag(UIButton.ButtonClickEnum.Single);
                if (SirenixEditorGUI.ToolbarButton("单击", isSingle))
                {
                    _uiButton.buttonClickEnum = isSingle ? _uiButton.buttonClickEnum &= (~UIButton.ButtonClickEnum.Single) :
                                                           _uiButton.buttonClickEnum |= UIButton.ButtonClickEnum.Single;
                }

                bool isDouble = _uiButton.buttonClickEnum.HasFlag(UIButton.ButtonClickEnum.Double);
                if (SirenixEditorGUI.ToolbarButton("双击", isDouble))
                {
                    _uiButton.buttonClickEnum = isDouble ? _uiButton.buttonClickEnum &= (~UIButton.ButtonClickEnum.Double) :
                                                           _uiButton.buttonClickEnum |= UIButton.ButtonClickEnum.Double;
                }

                bool isLongPress = _uiButton.buttonClickEnum.HasFlag(UIButton.ButtonClickEnum.LongPress);
                if (SirenixEditorGUI.ToolbarButton("长按", isLongPress))
                {
                    _uiButton.buttonClickEnum = isLongPress ? _uiButton.buttonClickEnum &= (~UIButton.ButtonClickEnum.LongPress) :
                                                           _uiButton.buttonClickEnum |= UIButton.ButtonClickEnum.LongPress;
                }

                bool isAll = _uiButton.buttonClickEnum.HasFlag(UIButton.ButtonClickEnum.All);
                if (SirenixEditorGUI.ToolbarButton("所有", isAll))
                {
                    _uiButton.buttonClickEnum = isAll ? _uiButton.buttonClickEnum = UIButton.ButtonClickEnum.None :
                                                           _uiButton.buttonClickEnum = UIButton.ButtonClickEnum.All;
                }
            }
            SirenixEditorGUI.EndHorizontalToolbar();

            EditorGUILayout.PropertyField(_itemId);
            EditorGUILayout.PropertyField(_clickThreshold);
            EditorGUILayout.PropertyField(_doubleClickThreshold);
            EditorGUILayout.PropertyField(_pressThreshold);
            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(target);
        }


    }
}
