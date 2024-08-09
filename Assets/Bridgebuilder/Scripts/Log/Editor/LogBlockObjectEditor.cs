using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LogBlockObject))]
public class LogBlockObjectEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		CustomEditorElements.UnitTestBox();
		LogBlockObject logBlockObject = (LogBlockObject)target;
		if (GUILayout.Button("Log With Length 1"))
		{
			LogBlock logBlock = new LogBlock(1);
			logBlockObject.SetupLogBlock(logBlock);
		}
		if (GUILayout.Button("Log With Length 4"))
		{
			LogBlock logBlock = new LogBlock(4);
			logBlockObject.SetupLogBlock(logBlock);
		}
	}
}
