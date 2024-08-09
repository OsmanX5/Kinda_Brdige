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
		CustomEditorElements.UnitTestBox();
		if (GUILayout.Button("CreateBridge"))
		{
			BridgeCreator bridgeCreator = (BridgeCreator)target;
			bridgeCreator.CreateBridge();
		}
	}
}
