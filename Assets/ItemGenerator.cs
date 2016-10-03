// 課題　---　★
using UnityEngine;
using System.Collections;


public class ItemGenerator : MonoBehaviour {
    // carPrefabを入れる
    public GameObject carPrefab;
    // coinPrefabを入れる
    public GameObject coinPrefab;
    // conePrefabを入れる
    public GameObject conePrefab;
    // スタート地点
    private int startPos = -160;
    // ゴール地点
    private int goalPos = 120;
    // アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // ★Unityちゃんのオブジェクト
    private GameObject unitychan;
    private GameObject Goal;
    // ★使用変数
    private float i;  //　障害物オブジェクトの生成（z軸）
    private float time;  // 時間トリガー

    // Use this for initialization
    void Start()
    {
        // ★Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        // ★Unityちゃんの現在位置を取得
        Vector3 difUni = unitychan.transform.position;
        // ★Unityちゃんのちょっと先に位置（オブジェクトの生成）
        Vector3 targetPos = difUni + new Vector3(0, 0, 30.0f);
        // ★時間間隔を一定にする
        this.time += Time.deltaTime;

        // ★ゴール地点を越えた場所にアイテムを生成しようとしているかどうか
        if (targetPos[2] >= (float)goalPos)
        {
            return;
        }

        // ★一定時間経過毎にオブジェクトを生成
        if (time > 1.0f)
        {
            this.time = 0;
            ItemCreate(targetPos);
        }

    }

    void ItemCreate(Vector3 pos)
    {
        i = pos[2];

        // ★Start関数より移動
        // どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                // コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {
                // レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    // アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    // 50%コインは位置：30％車は位置：10％何もなし
                    if (i <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        // 車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
        }
    }

}
