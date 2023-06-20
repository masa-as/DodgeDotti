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
                int randomIndex = Random.Range(0, list.Count); // ���X�g�͈͓̔��Ń����_���ȃC���f�b�N�X�𐶐�
                return list[randomIndex];
            }
        }
    }
}