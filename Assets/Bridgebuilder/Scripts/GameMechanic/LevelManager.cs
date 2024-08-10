using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class LevelManager : MonoBehaviour
{
    [SerializeField] LogBlocksCreator logBlocksCreator;
    [SerializeField] BridgeCreator bridgeCreator;
    [SerializeField] WinChecker winChecker;
	[SerializeField] CharacterControl character;
	[SerializeField] Animator transitionEffect;
	const int MAX_SIZE =14;
    static LevelManager _instance;
    public static LevelManager Instance => _instance;
    public BridgeCreator BridgeCreator => bridgeCreator;
	public LogBlocksCreator LogBlocksCreator => logBlocksCreator;
	private void Awake()
	{
		_instance = this;
	}
	private void Start()
	{
		winChecker.OnWin.AddListener(OnWin);
		InitTheGame(9);
	}
	void InitTheGame(int size)
	{
		if (size >= MAX_SIZE)
			SceneManager.LoadScene("End");
		character.MoveToStart();

		winChecker.Init();
		bridgeCreator.CreateBridge(size);
		logBlocksCreator.CreateLogBlocks(size);
	}

	private void OnWin()
	{
		character.MoveToTarget();
		StartCoroutine(OnWinCoroutine());
	}

	IEnumerator OnWinCoroutine()
	{
		yield return new WaitForSeconds(2f);
		transitionEffect.Play("Transition");
		yield return new WaitForSeconds(2f);
		InitTheGame(bridgeCreator.BridgeSize + 1);
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
