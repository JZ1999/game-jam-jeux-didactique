using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordSelect : MonoBehaviour
{

	private Sentence currentSentence;
	[SerializeField]
	private GameObject buttonPrefab;
	[SerializeField]
	private WordBuilder wordBuilder;

	private List<GameObject> currentWordButtons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	void clearGUIItems()
	{
		int count = currentWordButtons.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject wordButton = currentWordButtons[0];
			wordButton.SetActive(false);
			currentWordButtons.Remove(wordButton);
			Destroy(wordButton);
		}
	}

	public void setSentence(Sentence sentence)
	{
		clearGUIItems();
		List<string> tempSentences = new List<string>();
		currentSentence = sentence;

		foreach(string word in sentence.words)
			tempSentences.Add(word);
		foreach (string word in sentence.badWords)
			tempSentences.Add(word);

		Utils.Shuffle(tempSentences);

		foreach(string word in tempSentences)
		{
			GameObject prefab = Instantiate(buttonPrefab, transform);

			prefab.GetComponentInChildren<Text>().text = word;
			prefab.GetComponent<Button>().onClick.AddListener(() => wordBuilder.ActivateWord(word));
			currentWordButtons.Add(prefab);
		}
		
	}

}
