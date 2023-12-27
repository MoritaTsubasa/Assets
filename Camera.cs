using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject Player;// プレイヤー情報格納
    private Vector3 Offset;// 相対距離取得用

    // Start is called before the first frame update
    void Start()
    {
        //プレイヤーの情報を取得
        this.Player = GameObject.Find("PlayerModelWalk");

        // MainCameraとPlayerとの相対距離を求める
        Offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //新しいトランスフォームの値を代入する
        transform.position = Player.transform.position + Offset;
    }
}
