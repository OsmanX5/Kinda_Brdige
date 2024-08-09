using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeObject : MonoBehaviour
{
	[SerializeField] GameObject bridgeCellObjectPrefab;
    Bridge bridge;
	BridgeSidePoint startPoint;
	BridgeSidePoint endPoint;

	public void SetupBridge(Bridge bridge,BridgeSidePoint startPoint,BridgeSidePoint endPoint)
	{
		this.bridge = bridge;
		this.startPoint = startPoint;
		this.endPoint = endPoint;
	}
	public void UpdateBridgeObject()
	{
		float widthOffset = bridgeCellObjectPrefab.GetComponent<BridgeCellObject>().Width;
		Vector3 currentPosition = startPoint.Position;
		foreach (var cell in bridge.Cells)
		{
			// Update cell object
			GameObject cellObject = Instantiate(bridgeCellObjectPrefab, currentPosition, Quaternion.identity);
			cellObject.GetComponent<BridgeCellObject>().SetupBridgeCell(cell);
			currentPosition.x += widthOffset;
		}
	}
}
