using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewWord", menuName = "Word")]
public class Word : ScriptableObject
{
	public string word;
	public AudioSource audio;
	public Sprite img;
	public GameObject obj;
    public GameObject button;
}
