using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint; // 弾の発射位置
    public float bulletSpeed = 5f; // 弾の速度
    public float fireRate = 1f; // 連射間隔
    public int numberOfBullets = 3; // 同時に発射する弾の数

    private Transform player;// プレイヤーのTransform

    // Start is called before the first frame update
    void Start()
    {
        // 一定の間隔でShootメソッドを呼び出す
        InvokeRepeating("Shoot", 0f, fireRate);

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
        
    }

    void Shoot()
    {
        // 複数の弾を生成する
        for (int i = 0; i < numberOfBullets; i++)
        {
            // 弾のプレハブからインスタンスを生成し、発射位置に配置する
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // プレイヤーの方向を向く
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


            // 生成した弾に速度を与えるなどの設定を行う
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;

            // 各弾をわずかに異なる方向に向ける（例: ランダムな散布）
            bulletRb.velocity = Quaternion.Euler(0, Random.Range(-10f, 10f), 0) * bulletRb.velocity;
        }

    }

}
