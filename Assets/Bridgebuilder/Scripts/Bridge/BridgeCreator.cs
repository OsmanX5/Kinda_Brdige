using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCreator : MonoBehaviour
{
	[Range(8,12)]
    [SerializeField] int bridgeSize;
    [SerializeField] GameObject bridgeObjectPrefab;
	[SerializeField] BridgeSidePoint startPoint;
	[SerializeField] BridgeSidePoint endPoint;
	BridgeObject lastCreatedBridge;
	private void Start()
	{
		CreateBridge();

	}
	public void CreateBridge()
	{
		DestroyBridge();
		UpdateBridgeSidePointsPositions();
		GameObject bridgeObject = Instantiate(bridgeObjectPrefab, transform);
		lastCreatedBridge = bridgeObject.GetComponent<BridgeObject>();
		lastCreatedBridge.SetupBridge(new Bridge(bridgeSize),startPoint.transform.position);
	}
	public void DestroyBridge()
	{
		if(lastCreatedBridge!=null)
			DestroyImmediate(lastCreatedBridge.gameObject);
		lastCreatedBridge = null;
	}
	void UpdateBridgeSidePointsPositions()
	{
		float offset = bridgeSize / 2.0f;
		startPoint.transform.position = transform.position + new Vector3(-offset, 0, 0);
		endPoint.transform.position = transform.position + new Vector3(offset, 0, 0);
	}
}
