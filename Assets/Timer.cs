using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	[SerializeField]
	[Range(0, 120)]
	private float gameTime = 0;
	[HideInInspector]
	public float _gameTime = 0;
	public Slider timerUI;

    // Start is called before the first frame update
    void Start()
    {
		_gameTime = gameTime;
    }

	public void ReduceTime(float amount)
	{
		gameTime -= amount;
		if(gameTime < 0)
		{
			gameTime = 0;
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (gameTime > 0)
		{
			gameTime -= Time.deltaTime;
			timerUI.value = gameTime / _gameTime;
		}
		else
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
