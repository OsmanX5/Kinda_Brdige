using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BridgeCellObject : MonoBehaviour
{
    BridgeCell bridgeCell;
    [SerializeField] TextMeshPro cellNumber;
	[SerializeField] SpriteRenderer logvisual;
	Color originalHologramColor;
	public BridgeCellState CellState => bridgeCell.CellState;
	private void Start()
	{
		originalHologramColor = logvisual.color;
	}
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
			case BridgeCellState.Hovering:
				changeHologramToGreen();
				break;
			default:
				returnHologramToOriginal();
				break;
		}
	}
	void changeHologramToGreen()
	{
		logvisual.color = new Color(0, 1, 0, 0.5f);
	}
	void returnHologramToOriginal()
	{
		logvisual.color = originalHologramColor;
	}
	
}
