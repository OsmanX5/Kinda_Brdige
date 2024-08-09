using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeObject : MonoBehaviour
{
	[SerializeField] GameObject bridgeCellObjectPrefab;
	[SerializeField]BridgeSidePoint startPoint;
	[SerializeField]BridgeSidePoint endPoint;
    Bridge bridge;
	List<GameObject> bridgeCellObjects = new List<GameObject>();
	public void SetupBridge(Bridge bridge)
	{
		this.bridge = bridge;
		BuildTheBridge();
	}
	public void BuildTheBridge()
	{
		ClearBridge();
		bridgeCellObjects = bridge.BuildBridgeCells(bridgeCellObjectPrefab, startPoint.transform.position);
		foreach (var cellObject in bridgeCellObjects)
		{
			cellObject.transform.SetParent(transform);
		}
	}
	public void ClearBridge()
	{
		foreach (var cellObject in bridgeCellObjects)
		{
			DestroyImmediate(cellObject);
		}
		bridgeCellObjects.Clear();
	}
}
