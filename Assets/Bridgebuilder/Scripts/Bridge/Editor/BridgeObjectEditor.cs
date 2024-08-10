using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BridgeObject))]
public class BridgeObjectEditor : Editor
{
	[SerializeField] 
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		BridgeObject bridgeObject = (BridgeObject)target;
		CustomEditorElements.UnitTestBox();

		if (GUILayout.Button("Setup Bridge with width 5"))
		{
			bridgeObject.SetupBridge(new Bridge(5),Vector3.zero);
		}
		if (GUILayout.Button("Setup Bridge with width 8"))
		{
			bridgeObject.SetupBridge(new Bridge(8),Vector3.zero);
		}
		if (GUILayout.Button("Clear Bridge"))
		{
			bridgeObject.ClearBridge();
		}

	}
}
