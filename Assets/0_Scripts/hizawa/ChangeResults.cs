using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

using Tools;

//
using UnityEngine.UI;
//

public class ChangeResults: MonoBehaviour
{
    public int HighScoreChangePoint;//2�Ԗڂ���1�Ԗڂւ̐؂�ւ��|�C���g
    public int MidHighScoreChangePoint; //3�Ԗڂ���2�Ԗڂւ̐؂�ւ��|�C���g
    public int MidLowScoreChangePoint; // 4�Ԗڂ���3�Ԗڂւ̐؂�ւ��|�C���g
    public List<GameObject> HighestModelList;
    public List<GameObject> MidHighModelList;
    public List<GameObject> MidLowModelList;
    public List<GameObject> LowestModelList;
    public GameObject EDSystem;

    private float displayTime;
    private List<GameObject> PeopleList = new List<GameObject>();
    private List<GameObject> LowestModels = new List<GameObject>();
    private List<GameObject> MidLowModels = new List<GameObject>();
    private List<GameObject> MidHighModels = new List<GameObject>();
    private bool isMidLow = false;
    private bool isMidHigh = false;
    private bool isHighest = false;

    ListHandler listHandler = new ListHandler();



    void Start()
    {
        displayTime = EDSystem.GetComponent<EDManager>().display_time_sec; // �X�R�A�̃J�E���g�\������
        List<GameObject> children = new List<GameObject>();
        int numChildren = transform.childCount;  // Prople�̎q�I�u�W�F�N�g(�J�v�Z��)�̐�
        for (int i = 0; i < numChildren; i++)
        {
            Transform child = transform.GetChild(i); // �q�I�u�W�F�N�g���擾
            children.Add(child.gameObject); // ���Ń\�[�g���邽�߂Ƀ��X�g�ɉ����Ă���
        }

        PeopleList = children.OrderBy(child => child.GetComponent<EDPerson>().distance).ToList(); //�v���C���[�Ǝq�I�u�W�F�N�g�̋����Ń\�[�g���APeopleList�Ɋi�[
        StartCoroutine(Pop()); //�R���[�`�����s(WaitTime������Pop()�����s�����)
    }


    IEnumerator Pop() // �l���o��������
    {
        float WaitTime = displayTime / PeopleList.Count; // WaitTime�̌v�Z�B���j��displayTime�ł��傤��PeopleList�̗v�f�����o������B
        for (int i = 0; i < PeopleList.Count; i++)
        {
            GameObject Person = PeopleList[i];
            Vector3 directionToPlayer = Vector3.zero - Person.transform.position; //�x�N�g������
            directionToPlayer.y = 0;
            Quaternion rotationToOrigin = Quaternion.LookRotation(directionToPlayer); //Player�̈ʒu�Ɍ�����ݒ�
            float cur_score = EDSystem.GetComponent<EDManager>().scorecount; //���Ԍo�߂�EDManager�ŃX�R�A���Z�̏����������Ă���B���̌v�Z���̒l���擾�B
            if (cur_score <= (float)MidLowScoreChangePoint) // ��ԓ_���Ⴂ�l���玟�_�ւ̐؂�ւ��|�C���g�ɂȂ�܂�
            {
                GameObject ob = Instantiate(listHandler.GetRandomElement(LowestModelList), Person.transform.position, rotationToOrigin);//��ԓ_���Ⴂ�l���o��������B
                LowestModels.Add(ob);//���Ƃňꊇ�ύX����̂ŁA���X�g�Ɋi�[���Ƃ��B

               

            }
            else if (cur_score <= (float)MidHighScoreChangePoint)// ���_�̐؂�ւ��|�C���g�ɂȂ�܂�
            {
                if (isMidLow == false) // ����Ȃ�
                {
                    ChangeHumen(listHandler.GetRandomElement(MidLowModelList), 0.5f); // �����̈�ԓ_���Ⴂ�l�́AMidLowModel�ɕϐg������
                    isMidLow = true;

                }
                GameObject ob = Instantiate(listHandler.GetRandomElement(MidLowModelList), Person.transform.position, rotationToOrigin);
                MidLowModels.Add(ob);
            }
            else if (cur_score <= (float)HighScoreChangePoint) //�ȉ����l
            {
                if (isMidHigh == false)
                {
                    ChangeHumen(listHandler.GetRandomElement(MidHighModelList), 0.5f);
                    isMidHigh = true;

                }
                GameObject ob = Instantiate(listHandler.GetRandomElement(MidHighModelList), Person.transform.position, rotationToOrigin);
                MidHighModels.Add(ob);
            }
            else
            {
                if (isHighest == false)
                {
                    ChangeHumen(listHandler.GetRandomElement(HighestModelList), 1.0f);
                    isHighest = true;
                }
                Instantiate(listHandler.GetRandomElement(HighestModelList), Person.transform.position, rotationToOrigin);
            }
            yield return new WaitForSeconds(WaitTime); //WaitTime�b�҂�
        }
    }

    void ChangeHumen(GameObject after, float ratio)
    {
        float len;
        if (isMidLow == false)
        {
            len = LowestModels.Count * ratio;
            for (int i = LowestModels.Count - 1; i >= len; i--)
            {
                GameObject ob = Instantiate(listHandler.GetRandomElement(MidLowModelList), LowestModels[i].transform.position, LowestModels[i].transform.rotation);
                Destroy(LowestModels[i]);
                LowestModels.RemoveAt(i);
                MidLowModels.Add(ob);
            }
            return;
        }
        if (isMidHigh == false)
        {
            len = LowestModels.Count * ratio;
            for (int i = LowestModels.Count - 1; i >= len; i--)
            {
                GameObject ob = Instantiate(listHandler.GetRandomElement(MidHighModelList), LowestModels[i].transform.position, LowestModels[i].transform.rotation);
                Destroy(LowestModels[i]);
                LowestModels.RemoveAt(i);
                MidHighModels.Add(ob);
            }
            len = MidLowModels.Count * ratio;
            for (int i = MidLowModels.Count - 1; i >= len; i--)
            {
                GameObject ob = Instantiate(listHandler.GetRandomElement(MidHighModelList), MidLowModels[i].transform.position, MidLowModels[i].transform.rotation);
                Destroy(MidLowModels[i]);
                MidLowModels.RemoveAt(i);
                MidHighModels.Add(ob);
            }
            return;
        }
        if (isHighest == false)
        {
            for (int i = LowestModels.Count - 1; i >= 0; i--)
            {
                Instantiate(listHandler.GetRandomElement(HighestModelList), LowestModels[i].transform.position, LowestModels[i].transform.rotation);
                Destroy(LowestModels[i]);
            }
            for (int i = MidLowModels.Count - 1; i >= 0; i--)
            {
                Instantiate(listHandler.GetRandomElement(HighestModelList), MidLowModels[i].transform.position, MidLowModels[i].transform.rotation);
                Destroy(MidLowModels[i]);
            }
            for (int i = MidHighModels.Count - 1; i >= 0; i--)
            {
                Instantiate(listHandler.GetRandomElement(HighestModelList), MidHighModels[i].transform.position, MidHighModels[i].transform.rotation);
                Destroy(MidHighModels[i]);
            }
            return;
        }
        return;
    }

    

}