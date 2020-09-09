using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSelect : MonoBehaviour
{

	private Sentence currentSentence;
	[SerializeField]
	private GameObject buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void setSentence(Sentence sentence)
	{
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

			prefab.GetComponentInChildren<TextMeshProUGUI>().SetText(word);
		}
		
	}

}
