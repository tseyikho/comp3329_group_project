using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AutoType : MonoBehaviour
{

	public float letterPause = 0.038f;
	public AudioSource sound;
	public TextMeshProUGUI text;

	string message;

	// Use this for initialization
	void Start()
	{
		text = GetComponent<TextMeshProUGUI>();
		message = text.text;
		text.text = "";
		StartCoroutine(TypeText());
	}

	IEnumerator TypeText()
	{
		foreach (char letter in message.ToCharArray())
		{
			sound.Play();
			yield return new WaitForSeconds((float)0.04);
			text.text += letter;
			yield return 0;
			yield return new WaitForSeconds(letterPause);
		}
	}
}
