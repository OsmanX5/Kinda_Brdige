using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LogBlockObject))]
public class LogBlockDrag : MonoBehaviour
{
	private bool dragging = false;
	private Vector3 offset;
	LogBlockObject logBlock=> GetComponent<LogBlockObject>();
	Vector3 StartPosition;
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
	}

	private void OnMouseUp()
	{
		// Stop dragging.
		dragging = false;
		BackToStartPosition();
	}
	void BackToStartPosition()
	{
		transform.position = StartPosition;
	}
}
