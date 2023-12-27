using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public Transform firePoint; // �e�̔��ˈʒu
    public float bulletSpeed = 5f; // �e�̑��x
    public float fireRate = 1f; // �A�ˊԊu
    public int numberOfBullets = 3; // �����ɔ��˂���e�̐�

    private Transform player;// �v���C���[��Transform

    // Start is called before the first frame update
    void Start()
    {
        // ���̊Ԋu��Shoot���\�b�h���Ăяo��
        InvokeRepeating("Shoot", 0f, fireRate);

        // �v���C���[��������i�O��F�v���C���[��"Player"�^�O���t���Ă���Ɖ���j
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (player == null)
        {
            Debug.LogError("�v���C���[��������܂���");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Shoot()
    {
        // �����̒e�𐶐�����
        for (int i = 0; i < numberOfBullets; i++)
        {
            // �e�̃v���n�u����C���X�^���X�𐶐����A���ˈʒu�ɔz�u����
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // �v���C���[�̕���������
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);


            // ���������e�ɑ��x��^����Ȃǂ̐ݒ���s��
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;

            // �e�e���킸���ɈقȂ�����Ɍ�����i��: �����_���ȎU�z�j
            bulletRb.velocity = Quaternion.Euler(0, Random.Range(-10f, 10f), 0) * bulletRb.velocity;
        }

    }

}
