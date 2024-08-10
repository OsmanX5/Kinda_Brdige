using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LogBlock
{
    LogBlockState logState;
    int numberOfLogs;
	public LogBlock(int numberOfLogs)
	{
		this.logState = LogBlockState.InShevel;
		this.numberOfLogs = numberOfLogs;
	}
	public LogBlockState GetCurrentLogState => logState;
	public int GetNumberofLogs => numberOfLogs;

}
