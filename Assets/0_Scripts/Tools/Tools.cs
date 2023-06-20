using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class ListHandler
    {
        public T GetRandomElement<T>(List<T> list)
        {
            // ���X�g���烉���_���ȗv�f���o��
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