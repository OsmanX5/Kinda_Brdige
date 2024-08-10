using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogBlocksCreator : MonoBehaviour
{
    [SerializeField] GameObject logBlockObjectPrefab;
    [SerializeField] Transform logblocksParent;
    [SerializeField] Transform ShelfStartPoint;
    [SerializeField,Range(1,4)] int logBlocksCount = 2;
    const int MAXS_SHELF_COUNT =16;
        
	List<LogBlockObject> createdLogBlocks = new List<LogBlockObject>();
	public void CreateLogBlocks(int GrandTarget = 8)
    {
        DestroyOldBlocks();
        List<int> sizes = CreateRandomizedLengthFitTarget(GrandTarget);
        foreach (int length in sizes) {
            CreateALogBlock(length);
		}
		RandomizeAndOrgnize();
	}
    public void RandomizeAndOrgnize()
    {
		RandomizeBlocks();
		OrgnizeBlocks();
	}
    void RandomizeBlocks()
    {
		createdLogBlocks = createdLogBlocks.Randomize().ToList();
	}
    void OrgnizeBlocks()
    {
        int n = createdLogBlocks.Count();
        float blockStartPosition = 0;
        float paddingSpace = 0.5f;
        
        for(int i = 0; i < n; i++)
        {
            Transform logBlock = createdLogBlocks[i].transform;
            Vector3 offset = new Vector3(blockStartPosition, 0, 0);
            logBlock.position = ShelfStartPoint.position + offset;
			blockStartPosition += createdLogBlocks[i].LogsCount + paddingSpace;
		}
    }
    void CreateALogBlock(int size)
    {
        GameObject created = Instantiate(logBlockObjectPrefab, logblocksParent);
        created.name = $"LogBlock X({size})";
        LogBlockObject logblock = created.GetComponent<LogBlockObject>();
        logblock.SetupLogBlock(new LogBlock(size));
        createdLogBlocks.Add(logblock);
	}
    void DestroyOldBlocks()
    {
        logblocksParent.DestroyAllChildrens();
        createdLogBlocks = new List<LogBlockObject>();

	}

    List<int> CreateRandomizedLengthFitTarget(int target)
    {
        List<int> res = CreateRandomizedLength();
		while (!IsSubsetSumPossible(res.ToArray(), target))
		{
			res = CreateRandomizedLength();
		}
        return res;

	}
    List<int> CreateRandomizedLength()
    {
        List<int> res = new List<int>();
		int createdBlocksSize = 0;
		for (int i = 0; i < logBlocksCount; i++)
		{
			int available = MAXS_SHELF_COUNT - createdBlocksSize;
			int randomSize = Random.Range(1, Mathf.Min(available, 6));
			createdBlocksSize += randomSize;
            res.Add(randomSize);
		}
        return res;
    }
    public bool IsSubsetSumPossible(int[] arr, int target)
	{
		bool[] dp = new bool[target + 1];
		dp[0] = true;
		foreach (int num in arr)
		{
			for (int j = target; j >= num; j--)
			{
				if (dp[j - num])
				{
					dp[j] = true;
				}
			}
		}

		return dp[target];
	}
}
