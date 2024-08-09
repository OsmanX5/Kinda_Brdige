using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public static class CustomEditorElements
{
    public static void UnitTestBox()
	{
		GUILayout.BeginVertical(GUI.skin.box);
		GUILayout.FlexibleSpace();
		GUILayout.Space(10);
		GUIStyle labelStyle = new GUIStyle(EditorStyles.centeredGreyMiniLabel);
		labelStyle.fontSize = 16; // Increase the font size to 16
		GUILayout.Label("Unit Test", labelStyle);
		GUILayout.Space(10);

		GUILayout.FlexibleSpace();
		GUILayout.EndVertical();

	}
}
