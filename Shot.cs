using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // �Q�[���I�u�W�F�N�g���C���X�y�N�^�[����Q�Ƃ��邽�߂̕ϐ�
    //public GameObject Bullet;

    public GameObject bulletPrefab; // �e�̃v���n�u
    public Transform firePoint;     // �e�̔��ˈʒu

    public float bulletSpeed = 10f; // �e�̑���

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {


        //// �X�y�[�X�L�[�������ꂽ���𔻒�
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //   Instantiate(Bullet, transform.position, Quaternion.identity); 
        //}

        // �X�y�[�X�L�[�������ꂽ��e�𔭎�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        // �e�̃C���X�^���X�𐶐�
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �e�ɑ�����^����
        bullet.GetComponent<Rigidbody>().velocity = transform.up * bulletSpeed;

        // 2�b��ɒe���폜
        Destroy(bullet, 2f);
    }
}
