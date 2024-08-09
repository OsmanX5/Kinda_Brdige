using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BridgeCreator))]
public class BridgeCreatorEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		BridgeCreator bridgeCreator = (BridgeCreator)target;
		CustomEditorElements.UnitTestBox();
		if (GUILayout.Button("CreateBridge"))
		{
			bridgeCreator.CreateBridge();
		}
		if (GUILayout.Button("Delet Bridge"))
		{
			bridgeCreator.DestroyBridge();
		}

	}
}
