using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
	[SerializeField]
	private int amountOfProblems = 2;

	private int currentPhraseId = 0;

	void Start()
    {
		//TODO make random
		Utils.Shuffle(availableSentences);
		currentPhrases = availableSentences.GetRange(0, amountOfProblems);
		NextPhrase();
    }

	void NextPhrase()
	{
		if (currentPhraseId >= currentPhrases.Count)
		{
			wordBuilder.gotWordCorrect = false;
			SceneManager.LoadScene("win");
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
