using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
	private List<Sentence> currentPhrases;
	[SerializeField]
	private List<Sentence> availableSentences;
	[SerializeField]
	private WordSelect wordSelection;
	[SerializeField]
	private WordBuilder wordBuilder;
	[SerializeField]
	private AudioSource soundManager;

	private int currentPhraseId = 0;

	void Start()
    {
		//TODO make random
		Utils.Shuffle(availableSentences);
		currentPhrases = availableSentences.GetRange(0, 2);
		NextPhrase();
    }

	void NextPhrase()
	{
		if (currentPhraseId >= currentPhrases.Count)
		{
			Debug.Log("You win!");
			wordBuilder.gotWordCorrect = false;
			return;
		}

		wordBuilder.gotWordCorrect = false;
		wordSelection.setSentence(currentPhrases[currentPhraseId]);
		StartCoroutine(wordBuilder.setSentence(currentPhrases[currentPhraseId]));
		soundManager.clip = currentPhrases[currentPhraseId].audio;
		soundManager.Play();
		currentPhraseId++;
	}

	public void PlayPhraseSound()
	{
		soundManager.Play();
	}

    // Update is called once per frame
    void Update()
    {
		if (wordBuilder.gotWordCorrect)
		{
			NextPhrase();
		}
    }
}
