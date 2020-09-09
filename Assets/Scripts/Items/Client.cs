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
		currentPhrases = availableSentences;
		NextPhrase();
    }

	void NextPhrase()
	{
		wordSelection.setSentence(currentPhrases[currentPhraseId]);
		StartCoroutine(wordBuilder.setSentence(currentPhrases[currentPhraseId]));
		soundManager.clip = currentPhrases[currentPhraseId].audio;
		soundManager.Play();
		currentPhraseId++;
		if (currentPhraseId >= currentPhrases.Count)
		{
			//Next minigame
		}
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
