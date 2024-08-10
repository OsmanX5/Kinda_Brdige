using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinChecker : MonoBehaviour
{
	public UnityEvent OnWin;
    public void Init()
    {
		LevelManager.Instance.BridgeCreator.OnCreateABridge += OnCreateABridge;
	}

	private void OnCreateABridge(BridgeObject bridge)
	{
		LevelManager.Instance.BridgeCreator.OnCreateABridge -= OnCreateABridge;
		bridge.OnCompleted += Bridge_OnCompleted;
	}

	private void Bridge_OnCompleted()
	{
		Debug.Log("Win");
		OnWin?.Invoke();
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
