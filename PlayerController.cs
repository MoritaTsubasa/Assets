using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float power = 5;
    public float speed = 10;
    new public Rigidbody rigidbody;
    private bool jampFlag = false;
    //[SerializeField]  private Animator animator;
    public Animator animator;
    bool isWalk;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        isWalk = false;

        // 自機の左右の移動
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * transform.forward * Time.deltaTime;
            isWalk = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * transform.forward * Time.deltaTime;
            isWalk = true;
        }

        // 自機のジャンプ
        if (Input.GetKey(KeyCode.W) && !jampFlag)
        {
            rigidbody.velocity = Vector3.up * power;
            jampFlag = true;
        }

        // Animatorにキャラクターや環境のパラメータ設定を設定する
        ApplyAnimatorParameter();
        
    }

    void ApplyAnimatorParameter()
    {
        // Animatorにキャラクターや環境のパラメータを設定
        var speed = Mathf.Abs(power);
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", isWalk);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Plane"))
        {
            jampFlag = false;
        }
    }

}
