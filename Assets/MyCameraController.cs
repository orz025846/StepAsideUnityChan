// 課題、発展課題---★
using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {
    // Unityちゃんのオブジェクト
    private GameObject unitychan;
    // Unityちゃんとカメラの距離
    private float difference;

    // ★carPrefabを入れる
    public GameObject carPrefab;
    // ★coinPrefabを入れる
    public GameObject coinPrefab;
    // ★conePrefabを入れる
    public GameObject conePrefab;

    // ★カメラとオブジェクトの距離
    private float differenceObj;

    // Use this for initialization
    void Start () {
        // Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        // Unityちゃんとカメラの位置（z座標）の差を求める
        this.difference = unitychan.transform.position.z - this.transform.position.z;
        
	}
	
	// Update is called once per frame
	void Update () {
        // Unityちゃんの位置に合わせてカメラの位置を移動
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
	
	}
}
