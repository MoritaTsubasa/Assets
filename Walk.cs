using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Animator�R���|�[�l���g���擾
        // StateMachineBehaviour ���� GetComponent ���g���ꍇ�͈����� animator ���g�p
        animator = animator.GetComponent<Animator>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // ��������̏����ŕ����A�j���[�V�����ɐ؂�ւ����
        if (Input.GetKey(KeyCode.W))
        {
            // "Walk"�Ƃ����g���K�[���Z�b�g���ĕ����A�j���[�V�����֐؂�ւ���
            animator.SetTrigger("Walk");
        }
        else
        {
            // "Walk"�g���K�[�����Z�b�g���Ď~�܂��Ă���A�j���[�V�����֖߂�
            animator.ResetTrigger("Walk");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}