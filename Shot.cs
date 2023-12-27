using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // ゲームオブジェクトをインスペクターから参照するための変数
    //public GameObject Bullet;

    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint;     // 弾の発射位置

    public float bulletSpeed = 10f; // 弾の速さ

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


        //// スペースキーが押されたかを判定
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //   Instantiate(Bullet, transform.position, Quaternion.identity); 
        //}

        // スペースキーが押されたら弾を発射
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        // 弾のインスタンスを生成
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 弾に速さを与える
        bullet.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;

        // 2秒後に弾を削除
        Destroy(bullet, 2f);
    }
}
