using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BridgeCell
{
	BridgeCellState cellState;
	public BridgeCellState CellState => cellState;
	int index;
	public int Index => index;
	public void SetBrdigeIndex(int index)
	{
		this.index = index;
	}
}
