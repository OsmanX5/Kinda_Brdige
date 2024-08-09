using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BridgeCellObject : MonoBehaviour
{
    BridgeCell bridgeCell;
    [SerializeField] TextMeshPro cellNumber;
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
}
