using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LogBlockObject))]
public class LogBlockMechanism : MonoBehaviour
{
	private bool dragging = false;
	private Vector3 offset;
	public LogBlockObject logBlock=> GetComponent<LogBlockObject>();
	Vector3 StartPosition;
	public event Action<LogBlockMechanism> OnRelease;
	public event Action<LogBlockMechanism> OnPicked;
	public bool IsInBridgeArea;
	private void Start()
	{
		StartPosition = transform.position;
	}
	void Update()
	{
		if (dragging)
		{
			transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
		}
	}

	private void OnMouseDown()
	{
		logBlock.State = LogBlockState.Draging;
		offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		dragging = true;
		OnPicked?.Invoke(this);
	}

	private void OnMouseUp()
	{
		// Stop dragging.
		dragging = false;
		if (IsInBridgeArea)
			OnRelease?.Invoke(this);
		else
			BackToStartPosition();
	}
	public void BackToStartPosition()
	{
		transform.position = StartPosition;
	}
	public void SnapToPosition(Vector3 position)
	{
		transform.position = position;
	}
}
