using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeObject : MonoBehaviour
{
	[SerializeField] GameObject bridgeCellObjectPrefab;
	
    Bridge bridge;
	List<GameObject> bridgeCellObjects = new List<GameObject>();
	public void SetupBridge(Bridge bridge,Vector3 startPosition)
	{
		this.bridge = bridge;
		BuildTheBridge(startPosition);
	}
	public void BuildTheBridge(Vector3 startPosition)
	{
		ClearBridge();
		bridgeCellObjects = bridge.BuildBridgeCells(bridgeCellObjectPrefab, startPosition);
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
