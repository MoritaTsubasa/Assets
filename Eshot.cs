using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eshot : MonoBehaviour
{
    public float bulletSpeed = 5f; // �e�̑��x
    private Transform player; // �v���C���[��Transform

    // Start is called before the first frame update
    void Start()
    {
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
        // �v���C���[�̕���������
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // �O���ɐi��
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);

        // �v���C���[�Ƀ_���[�W��^���鏈���Ȃǂ�ǉ�
        Destroy(gameObject,2f); // ���̍s�͒e�̏Փˌ�ɒe��j�����邽��
    }

    void OnTriggerEnter(Collider other)
    {
        // �Փˎ��̏����i�Ⴆ�΃v���C���[�Ƀ_���[�W��^����Ȃǁj
        if (other.CompareTag("Player"))
        {
            // �v���C���[�Ƀ_���[�W��^���鏈���Ȃǂ�ǉ�
            Destroy(gameObject); // ���̍s�͒e�̏Փˌ�ɒe��j�����邽��
        }
    }

}
