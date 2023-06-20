using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class ListHandler
    {
        public T GetRandomElement<T>(List<T> list)
        {
            // リストからランダムな要素取り出す
            if (list == null || list.Count == 0)
            {
                return default(T);
            }
            else
            {
                int randomIndex = Random.Range(0, list.Count);
                return list[randomIndex];
            }
        }
    }
}