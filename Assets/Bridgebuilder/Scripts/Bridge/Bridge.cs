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
			cells.Add(new BridgeCell());
		}
	}
}
