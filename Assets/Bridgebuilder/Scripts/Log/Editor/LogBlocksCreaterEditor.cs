using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(LogBlocksCreator))]
public class LogBlocksCreaterEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		CustomEditorElements.UnitTestBox();
		LogBlocksCreator logBlocksCreator = (LogBlocksCreator)target;

		if(GUILayout.Button("Create Log Blocks"))
		{
			logBlocksCreator.CreateLogBlocks();
		}
		if (GUILayout.Button("Randomize and Ornize"))
		{
			logBlocksCreator.RandomizeAndOrgnize();
		}
	}
}
