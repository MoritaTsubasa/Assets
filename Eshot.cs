using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eshot : MonoBehaviour
{
    public float bulletSpeed = 5f; // 弾の速度
    private Transform player; // プレイヤーのTransform

    // Start is called before the first frame update
    void Start()
    {
        // プレイヤーを見つける（前提：プレイヤーに"Player"タグが付いていると仮定）
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("プレイヤーが見つかりません");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの方向を向く
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // 前方に進む
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        // プレイヤーにダメージを与える処理などを追加
        Destroy(gameObject,2f); // この行は弾の衝突後に弾を破棄するため
    }

    void OnTriggerEnter(Collider other)
    {
        // 衝突時の処理（例えばプレイヤーにダメージを与えるなど）
        if (other.CompareTag("Player"))
        {
            // プレイヤーにダメージを与える処理などを追加
            Destroy(gameObject); // この行は弾の衝突後に弾を破棄するため
        }
    }

}
