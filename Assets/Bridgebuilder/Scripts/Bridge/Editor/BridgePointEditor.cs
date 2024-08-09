using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BridgePointEditor : Editor
{
    static string bridgePointPrefabPath = "Assets/Bridgebuilder/Prefabs/BridgePoint.prefab";
	[MenuItem("GameObject/Bridgebuilder/Create Bridge Point")]
    public static void CreateBridgePoint()
    {
		GameObject bridgePointPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(bridgePointPrefabPath);
		GameObject createdPoint =(GameObject) PrefabUtility.InstantiatePrefab(bridgePointPrefab);
        createdPoint.name = "Bridge Side Point";

	}
}
