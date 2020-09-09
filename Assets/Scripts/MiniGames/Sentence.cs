using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSentence", menuName = "Sentence")]
public class Sentence : ScriptableObject
{
	public List<string> words;
	public List<string> badWords;
	public AudioClip audio;
}
