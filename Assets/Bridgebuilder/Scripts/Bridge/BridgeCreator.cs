using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCreator : MonoBehaviour
{
    [SerializeField] int bridgeSize;
    [SerializeField] GameObject bridgeObjectPrefab;

    BridgeObject lastCreatedBridge;
	public void CreateBridge()
	{
		if (lastCreatedBridge != null)
		{
			DestroyImmediate(lastCreatedBridge.gameObject);
		}
		GameObject bridgeObject = Instantiate(bridgeObjectPrefab, transform);
		lastCreatedBridge = bridgeObject.GetComponent<BridgeObject>();
		lastCreatedBridge.SetupBridge(new Bridge(bridgeSize));
	}
}
