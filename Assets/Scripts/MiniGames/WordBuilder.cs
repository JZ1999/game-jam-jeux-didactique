using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordBuilder : MonoBehaviour
{
	private Sentence currentSentence;
	[SerializeField]
	private GameObject buttonPrefabPlaceholder;
	[SerializeField]
	private GameObject buttonPrefabWord;
	[SerializeField]
	[Range(0,100)]
	private float offsetY;
	
	public bool gotWordCorrect = false;

	private List<GameObject> buttonPlaceholders = new List<GameObject>();
	private List<GameObject> buttonWords = new List<GameObject>();

	public IEnumerator setSentence(Sentence sentence)
	{
		clearGUIItems();
		currentSentence = sentence;

		foreach (string word in currentSentence.words)
		{
			GameObject prefabPlaceholder = Instantiate(buttonPrefabPlaceholder, transform);
			buttonPlaceholders.Add(prefabPlaceholder);
		}
		yield return new WaitForSeconds(1);

		for(int i = 0; i < buttonPlaceholders.Count; i++)
		{
			GameObject placeholder = buttonPlaceholders[i];
			GameObject prefabWord = Instantiate(buttonPrefabWord, transform.parent);
			prefabWord.GetComponent<RectTransform>().position = placeholder.GetComponent<RectTransform>().position;
			prefabWord.transform.position = new Vector3(prefabWord.transform.position.x, prefabWord.transform.position.y + offsetY, 0);
			prefabWord.SetActive(false);
			buttonWords.Add(prefabWord);

			prefabWord.GetComponentInChildren<TextMeshProUGUI>().SetText(currentSentence.words[i]);
		}
		

	}

	void clearGUIItems()
	{
		int count = buttonPlaceholders.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject placeholderObj = buttonPlaceholders[0];
			placeholderObj.SetActive(false);
			buttonPlaceholders.Remove(placeholderObj);
			Destroy(placeholderObj);
		}

		count = buttonWords.Count;
		for (int i = 0; i < count; i++)
		{
			GameObject wordObj = buttonWords[0];
			wordObj.SetActive(false);
			buttonWords.Remove(wordObj);
			Destroy(wordObj);
		}
	}

	public void ActivateWord(string word)
	{
		foreach(GameObject correctWordObject in buttonWords)
		{
			string correctWord = correctWordObject.GetComponent<TextMeshProUGUI>().text;

			if (correctWord == word)
			{
				correctWordObject.SetActive(true);
				gotWordCorrect = DidGetWordCorrect();
			}
		}
	}

	public bool DidGetWordCorrect()
	{
		bool correct = true;
		foreach (GameObject word in buttonWords)
		{
			correct &= word.activeSelf;
		}
		return correct;
	}


}
