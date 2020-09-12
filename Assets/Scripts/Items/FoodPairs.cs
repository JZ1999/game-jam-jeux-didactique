using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewFoodPair", menuName = "FoodPair")]

public class FoodPairs : ScriptableObject
{
	public Sprite goodImage;
	public Sprite badImage;
	public AudioClip audio;
}
