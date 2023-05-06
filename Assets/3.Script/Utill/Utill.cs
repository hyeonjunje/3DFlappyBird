using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utill
{
    public static List<T> GetShuffleList<T>(this List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i);

            T temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

        return list;
    }
}
