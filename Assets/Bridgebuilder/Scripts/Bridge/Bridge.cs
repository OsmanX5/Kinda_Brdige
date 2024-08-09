 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge 
{
    List<BridgeCell> cells;
	public List<BridgeCell> Cells => cells;

	public Bridge(int size)
	{
		cells = new List<BridgeCell>();
		for (int i = 0; i < size; i++)
		{
			cells.Add(new BridgeCell(i));

		}
	}
	public List<GameObject> BuildBridgeCells(GameObject bridgeCellObjectPrefab,Vector3 startPosition)
	{
		List<GameObject> cellObjects = new List<GameObject>();
		float widthOffset = bridgeCellObjectPrefab.GetComponent<BridgeCellObject>().Width;
		Vector3 currentPosition = startPosition;
		foreach (var cell in cells)
		{
			// Update cell object
			GameObject cellObject = GameObject.Instantiate(bridgeCellObjectPrefab, currentPosition, Quaternion.identity);
			cellObject.name = "Bridge Cell";

			cellObject.GetComponent<BridgeCellObject>().SetupBridgeCell(cell);
			currentPosition.x += widthOffset;
			cellObjects.Add(cellObject);
		}
		return cellObjects;
	}
}
