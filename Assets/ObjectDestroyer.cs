// 課題、発展課題---★
// ★課題用追加スクリプト
using UnityEngine;
using System.Collections;

public class ObjectDestroyer : MonoBehaviour {

    private float differenceObj;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        // オブジェクトとカメラの位置の差分
        this.differenceObj = this.transform.position.z - Camera.main.transform.position.z;

        // オブジェクト位置がカメラ位置より後方で消滅
        if (differenceObj < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
