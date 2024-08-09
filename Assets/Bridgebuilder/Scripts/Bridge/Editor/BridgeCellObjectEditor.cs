using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BridgeCellObject))]
public class BridgeCellObjectEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		if(GUILayout.Button("Setup Bridge Cell to Index 0"))
		{
			BridgeCellObject bridgeCellObject = (BridgeCellObject)target;
			BridgeCell bridgeCell = new BridgeCell(0);
			bridgeCellObject.SetupBridgeCell(bridgeCell);
		}
		if(GUILayout.Button("Update Cell Object"))
		{
			BridgeCellObject bridgeCellObject = (BridgeCellObject)target;
			bridgeCellObject.UpdateCellObject();
		}
	}
}
