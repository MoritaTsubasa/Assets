using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private GameObject Player;// �v���C���[���i�[
    private Vector3 Offset;// ���΋����擾�p

    // Start is called before the first frame update
    void Start()
    {
        //�v���C���[�̏����擾
        this.Player = GameObject.Find("PlayerModelWalk");

        // MainCamera��Player�Ƃ̑��΋��������߂�
        Offset = transform.position - Player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //�V�����g�����X�t�H�[���̒l��������
        transform.position = Player.transform.position + Offset;
    }
}
