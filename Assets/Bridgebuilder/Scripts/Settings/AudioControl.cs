using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    [SerializeField] AudioSource aud;
    [SerializeField] Button MuteButton;
    [SerializeField] Button PlayAudioButton;
	private void Start()
	{
		MuteButton.gameObject.SetActive(true);
		PlayAudioButton.gameObject.SetActive(false);
		MuteButton.onClick.AddListener(Mute);
		PlayAudioButton.onClick.AddListener(PlayAudio);
	}

	private void PlayAudio()
	{
		aud.mute = false;
		MuteButton.gameObject.SetActive(true);
		PlayAudioButton.gameObject.SetActive(false);
	}

	private void Mute()
	{
		aud.mute = true;
		MuteButton.gameObject.SetActive(false);
		PlayAudioButton.gameObject.SetActive(true);
	}
}
