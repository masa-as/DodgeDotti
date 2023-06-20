using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class ListHandler
    {
        public T GetRandomElement<T>(List<T> list)
        {
            if (list == null || list.Count == 0)
            {
                return default(T);
            }
            else
            {
                int randomIndex = Random.Range(0, list.Count); // リストの範囲内でランダムなインデックスを生成
                return list[randomIndex];
            }
        }
    }
}