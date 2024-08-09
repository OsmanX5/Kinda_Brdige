using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BridgeObject))]
public class BridgeObjectEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		CustomEditorElements.UnitTestBox();
		if (GUILayout.Button("Setup Bridge with width 5"))
		{
			BridgeObject bridgeObject = (BridgeObject)target;
			bridgeObject.SetupBridge(new Bridge(5),Vector3.zero);
		}
		if (GUILayout.Button("Setup Bridge with width 8"))
		{
			BridgeObject bridgeObject = (BridgeObject)target;
			bridgeObject.SetupBridge(new Bridge(8),Vector3.zero);
		}
		if (GUILayout.Button("Clear Bridge"))
		{
			BridgeObject bridgeObject = (BridgeObject)target;
			bridgeObject.ClearBridge();
		}
	}
}
