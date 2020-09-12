using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

static public class Utils
{
	private static System.Random rng = new System.Random();

	public static void Shuffle<T>(this IList<T> list)
	{
		int n = list.Count;
		while (n > 1)
		{
			n--;
			int k = Utils.rng.Next(n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}

    public static List<int> createList(int num) {

        List<int> list = new List<int>();
        num--;
        while (num > -1)
            list.Add(num--);
        Shuffle(list);
        return list;

    }
}
