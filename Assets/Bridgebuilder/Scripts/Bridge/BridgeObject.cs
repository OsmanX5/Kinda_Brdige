using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class BridgeObject : MonoBehaviour
{
	[SerializeField] GameObject bridgeCellObjectPrefab;
	[SerializeField] BoxCollider2D boxCollider;
    Bridge bridge;
	List<GameObject> bridgeCellObjects = new List<GameObject>();
	List<BridgeCellObject> bridgeCells => bridgeCellObjects.Select(cell => cell.GetComponent<BridgeCellObject>()).ToList();
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
		boxCollider.size = new Vector2(bridgeCellObjects.Count, 2);
		boxCollider.offset = new Vector2(0, -0.25f);
	}
	public void ClearBridge()
	{
		foreach (var cellObject in bridgeCellObjects)
		{
			DestroyImmediate(cellObject);
		}
		bridgeCellObjects.Clear();
		boxCollider.size = Vector2.zero;
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.TryGetComponent<LogBlockObject>(out LogBlockObject logBlock))
		{
			RefreshCells();
			int startIndex = GetIndexInBridge(logBlock.transform.position);
			if(startIndex + logBlock.LogsCount > bridgeCells.Count)
				return;
			List<BridgeCellObject> hovered = bridgeCells.GetRange(startIndex, logBlock.LogsCount);
			if(hovered.Any(cell => cell.CellState == BridgeCellState.Used))
				return;
			UpdateCellsState(hovered);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent<LogBlockObject>(out LogBlockObject logBlock))
		{
			RefreshCells();
		}
	}
	void UpdateCellsState(List<BridgeCellObject> bridgeCellObjects)
	{
		foreach(var cell in bridgeCellObjects)
		{
			cell.UpdateCellState(BridgeCellState.Hovering);
		}
	}
	void RefreshCells()
	{
		foreach(var cell in bridgeCells)
		{
			if (cell.CellState == BridgeCellState.Used)
				continue;
			cell.UpdateCellState(BridgeCellState.Hologram);
		}
	}
	int GetIndexInBridge(Vector3 position)
	{
		var closerCell = bridgeCellObjects.OrderBy(cell => Vector3.Distance(position, cell.transform.position)).FirstOrDefault();
		return bridgeCellObjects.IndexOf(closerCell);
	}
}
