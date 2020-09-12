using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ClientOrder : MonoBehaviour
{

	[SerializeField]
	private List<GameObject> clouds = new List<GameObject>();
	[SerializeField]
	private List<FoodPairs> foodPairs = new List<FoodPairs>();
	[SerializeField]
	private AudioSource audio;
	[SerializeField]
	private int amountOfProblems = 2;

	private int currentFoodPair = 0;
	private System.Random random;

	void Start()
    {
		random = new System.Random((int)DateTime.Now.Ticks);
		Utils.Shuffle(foodPairs);
		NextPair();
    }

	void NextPair()
	{
		if (currentFoodPair >= foodPairs.Count)
		{
			Debug.Log("You win");
			SceneManager.LoadScene("Fourth Minigame");
			return;
		}
		int rInt = random.Next(2);

		clouds[rInt].GetComponentInChildren<SpriteRenderer>().sprite = foodPairs[currentFoodPair].goodImage;
		clouds[rInt].GetComponentInChildren<Button>().onClick.RemoveAllListeners();
		clouds[rInt].GetComponentInChildren<Button>().onClick.AddListener(() => CheckClicked(true));

		clouds[(rInt + 1) % 2].GetComponentInChildren<SpriteRenderer>().sprite = foodPairs[currentFoodPair].badImage;
		clouds[(rInt + 1) % 2].GetComponentInChildren<Button>().onClick.RemoveAllListeners();
		clouds[(rInt + 1) % 2].GetComponentInChildren<Button>().onClick.AddListener(() => CheckClicked(false));

		audio.clip = foodPairs[currentFoodPair].audio;
		audio.Play();
	}

	public void CheckClicked(bool goodImage)
	{
		if (goodImage)
		{
			Debug.Log("Good Image");
			currentFoodPair++;
			NextPair();
		}
		else
		{
			Debug.Log("Bad Image");
			GetComponent<Timer>().ReduceTime(GetComponent<Timer>()._gameTime/10);
		}
	}

	public void PlayPhraseSound()
	{
		audio.Play();
	}
}
