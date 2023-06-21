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
    public int HighScoreChangePoint;//2番目から1番目への切り替えポイント
    public int MidHighScoreChangePoint; //3番目から2番目への切り替えポイント
    public int MidLowScoreChangePoint; // 4番目から3番目への切り替えポイント
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
        displayTime = EDSystem.GetComponent<EDManager>().display_time_sec; // スコアのカウント表示時間
        List<GameObject> children = new List<GameObject>();
        int numChildren = transform.childCount;  // Propleの子オブジェクト(カプセル)の数
        for (int i = 0; i < numChildren; i++)
        {
            Transform child = transform.GetChild(i); // 子オブジェクトを取得
            children.Add(child.gameObject); // 次でソートするためにリストに加えておく
        }

        PeopleList = children.OrderBy(child => child.GetComponent<EDPerson>().distance).ToList(); //プレイヤーと子オブジェクトの距離でソートし、PeopleListに格納
        StartCoroutine(Pop()); //コルーチン実行(WaitTimeおきにPop()が実行される)
    }


    IEnumerator Pop() // 人を出現させる
    {
        float WaitTime = displayTime / PeopleList.Count; // WaitTimeの計算。方針はdisplayTimeでちょうどPeopleListの要素数が出現する。
        for (int i = 0; i < PeopleList.Count; i++)
        {
            GameObject Person = PeopleList[i];
            Vector3 directionToPlayer = Vector3.zero - Person.transform.position; //ベクトル差分
            directionToPlayer.y = 0;
            Quaternion rotationToOrigin = Quaternion.LookRotation(directionToPlayer); //Playerの位置に向きを設定
            float cur_score = EDSystem.GetComponent<EDManager>().scorecount; //時間経過でEDManagerでスコア加算の処理をさせている。その計算中の値を取得。
            if (cur_score <= (float)MidLowScoreChangePoint) // 一番点数低い人から次点への切り替えポイントになるまで
            {
                GameObject ob = Instantiate(listHandler.GetRandomElement(LowestModelList), Person.transform.position, rotationToOrigin);//一番点数低い人を出現させる。
                LowestModels.Add(ob);//あとで一括変更するので、リストに格納しとく。

               

            }
            else if (cur_score <= (float)MidHighScoreChangePoint)// 次点の切り替えポイントになるまで
            {
                if (isMidLow == false) // 初回なら
                {
                    ChangeHumen(listHandler.GetRandomElement(MidLowModelList), 0.5f); // 半分の一番点数低い人は、MidLowModelに変身させる
                    isMidLow = true;

                }
                GameObject ob = Instantiate(listHandler.GetRandomElement(MidLowModelList), Person.transform.position, rotationToOrigin);
                MidLowModels.Add(ob);
            }
            else if (cur_score <= (float)HighScoreChangePoint) //以下同様
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
            yield return new WaitForSeconds(WaitTime); //WaitTime秒待つ
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