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
		if (GUILayout.Button("Setup Bridge with width5 "))
		{
			BridgeObject bridgeObject = (BridgeObject)target;
			bridgeObject.SetupBridge(new Bridge(5));
		}
	}
}
