using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCreator : MonoBehaviour
{
	[Range(8,14)]
    [SerializeField] int bridgeSize;
    [SerializeField] GameObject bridgeObjectPrefab;
	[SerializeField] BridgeSidePoint startPoint;
	[SerializeField] BridgeSidePoint endPoint;
	public int BridgeSize => bridgeSize;
	BridgeObject ActiveBridge;
	public event Action<BridgeObject> OnCreateABridge;

	public void CreateBridge(int size)
	{
		bridgeSize = size;
		CreateBridge();
	}
	public void CreateBridge()
	{
		DestroyBridge();
		UpdateBridgeSidePointsPositions();
		GameObject bridgeObject = Instantiate(bridgeObjectPrefab, transform);
		ActiveBridge = bridgeObject.GetComponent<BridgeObject>();
		ActiveBridge.SetupBridge(new Bridge(bridgeSize),startPoint.transform.position);
		OnCreateABridge?.Invoke(ActiveBridge);
	}
	public void DestroyBridge()
	{
		if(ActiveBridge!=null)
			DestroyImmediate(ActiveBridge.gameObject);
		ActiveBridge = null;
	}
	void UpdateBridgeSidePointsPositions()
	{
		float offset = bridgeSize / 2.0f;
		startPoint.transform.position = transform.position + new Vector3(-offset, 0, 0);
		endPoint.transform.position = transform.position + new Vector3(offset, 0, 0);
	}
}
