using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBlockObject : MonoBehaviour
{
    LogBlock logBlock;
    [SerializeField] GameObject logVisual;
    [SerializeField] Transform logVisualsParent;
    [SerializeField] BoxCollider2D logBlockCollider;
    public LogBlockState State;
    public void SetupLogBlock(LogBlock logBlock)
    {
        if (logBlock.GetNumberofLogs < 0)
            return;
        this.logBlock = logBlock;
        CreateLogBlockVisuals();
		logBlockCollider.size =new Vector2(logBlock.GetNumberofLogs,1.5f);
        logBlockCollider.offset = new Vector2((logBlock.GetNumberofLogs/2.0f),-0.25f);
	}
    void CreateLogBlockVisuals()
    {
        DestroyLogBlock();

		int n = logBlock.GetNumberofLogs;
        for(int i = 0; i < n; i++)
        {
			GameObject created = Instantiate(logVisual, logVisualsParent);
            created.transform.localPosition += new Vector3(i, 0, 0);
		}
    }
    public void DestroyLogBlock()
    {
        logVisualsParent.DestroyAllChildrens();
	}
    
    public int LogsCount => logBlock.GetNumberofLogs;

}
