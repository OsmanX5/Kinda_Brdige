using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class BridgeCellObject : MonoBehaviour
{
    BridgeCell bridgeCell;
    [SerializeField] TextMeshPro cellNumber;
	[SerializeField] SpriteRenderer logvisual;
	public BridgeCellState CellState => bridgeCell.CellState;

	public float Width = 1f;
    public void SetupBridgeCell(BridgeCell bridgeCell)
    {
		this.bridgeCell = bridgeCell;
		UpdateCellObject();
	}
	public void UpdateCellObject()
	{
		cellNumber.text = bridgeCell.Index.ToString();
	}
	public void UpdateCellState(BridgeCellState newState)
	{
		bridgeCell.CellState = newState;
		switch (bridgeCell.CellState)
		{
			case BridgeCellState.Hologram:
				returnHologramToOriginal();
				break;
			case BridgeCellState.Hovering:
				changeHologramToGreen();
				break;
			case BridgeCellState.Used:
				Hide();
				break;
			default:
				returnHologramToOriginal();
				break;
		}
	}

	private void Hide()
	{
		logvisual.color = new Color(0, 0, 0, 0);
	}

	void changeHologramToGreen()
	{
		logvisual.color = new Color(0, 1, 0, 0.5f);
	}
	void returnHologramToOriginal()
	{
		logvisual.color = new Color(1, 1, 1, 0.5f);
	}
	
}
