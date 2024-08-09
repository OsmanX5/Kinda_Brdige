using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Extenstions 
{
    public static void DestroyAllChildrens(this Transform t)
    {
		int n = t.childCount;
		for (int i = 0; i < n; i++)
		{
			Transform.DestroyImmediate(t.GetChild(0).gameObject);
		}
	}
	public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
	{
		System.Random rnd = new System.Random();
		return source.OrderBy((item) => rnd.Next());
	}
}
