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
	public List<BridgeCellObject> bridgeCells => bridgeCellObjects.Select(cell => cell.GetComponent<BridgeCellObject>()).ToList();
	List<BridgeCellObject> UnUsedCells => bridgeCells.Where(cell => cell.CellState != BridgeCellState.Used).ToList();
	List<LogBlockMechanism> SnapedLogBlocks = new List<LogBlockMechanism>();
	
	//for debugging
	BridgeCellState[] cellStates;
	public event Action OnCompleted;
	private void Update()
	{
		cellStates = bridgeCells.Select(cell => cell.CellState).ToArray();
	}
	//
	public void ShowHologram()
	{
		UpdateCellsState(bridgeCells, BridgeCellState.Hologram);
	}
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
		ShowHologram();
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

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.TryGetComponent<LogBlockObject>(out LogBlockObject logBlock))
		{
			logBlock.GetComponent<LogBlockMechanism>().OnRelease += OnLogBlockRelased;
			logBlock.GetComponent<LogBlockMechanism>().IsInBridgeArea =true;

		}
	}
	private void OnTriggerStay2D(Collider2D collision)
	{
		if(collision.TryGetComponent<LogBlockObject>(out LogBlockObject logBlock))
		{
			RefreshCells();
			if (!CanPlaceLogBlock(logBlock))
				return;
			UpdateCellsState(bridgeCellObjectsForBlock(logBlock),BridgeCellState.Hovering);
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.TryGetComponent<LogBlockObject>(out LogBlockObject logBlock))
		{
			RefreshCells();
			logBlock.GetComponent<LogBlockMechanism>().OnRelease -= OnLogBlockRelased;
			logBlock.GetComponent<LogBlockMechanism>().IsInBridgeArea = false;
		}
	}

	void RefreshCells()
	{
		UpdateCellsState(UnUsedCells, BridgeCellState.Hologram);
	}
	int GetIndexInBridge(Vector3 position)
	{
		var closerCell = bridgeCellObjects.OrderBy(cell => Vector3.Distance(position, cell.transform.position)).FirstOrDefault();
		return bridgeCellObjects.IndexOf(closerCell);
	}
	private void OnLogBlockRelased(LogBlockMechanism mechanism)
	{
		if (CanPlaceLogBlock(mechanism.logBlock)){
			int index = GetIndexInBridge(mechanism.transform.position);
			Vector3 worldPosition = GetWorldPosition(index);
			UpdateCellsState(bridgeCellObjectsForBlock(mechanism.logBlock), BridgeCellState.Used);
			mechanism.SnapToPosition(worldPosition);
			SnapedLogBlocks.Add(mechanism);
			mechanism.OnPicked += OnLogBLockPicked;
			if (UnUsedCells.Count == 0)
				OnCompleted?.Invoke();
		}
		else
		{
			mechanism.BackToStartPosition();
		}
	}

	private void OnLogBLockPicked(LogBlockMechanism mechanism)
	{
		UpdateCellsState(bridgeCellObjectsForBlock(mechanism.logBlock),BridgeCellState.Hologram);
		mechanism.OnPicked -= OnLogBLockPicked;
	}

	bool CanPlaceLogBlock(LogBlockObject logBlock)
	{
		int startIndex = GetIndexInBridge(logBlock.transform.position);
		if (startIndex + logBlock.LogsCount > bridgeCells.Count )
			return false;
		for(int i= startIndex; i < startIndex + logBlock.LogsCount; i++)
		{
			if (bridgeCells[i].CellState == BridgeCellState.Used)
				return false;
		}
		return true;
	}
	List<BridgeCellObject> bridgeCellObjectsForBlock(LogBlockObject logBlock)
	{
		int startIndex = GetIndexInBridge(logBlock.transform.position);
		return bridgeCells.GetRange(startIndex, logBlock.LogsCount);
	}
	void UpdateCellsState(List<BridgeCellObject> bridgeCellObjects,BridgeCellState state)
	{
		foreach (var cell in bridgeCellObjects)
		{
			cell.UpdateCellState(state);
		}
	}
	Vector3 GetWorldPosition(int cellIndex)
	{
		return bridgeCellObjects[cellIndex].transform.position;
	}

}



