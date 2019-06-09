﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndividualModelControll : MonoBehaviour
{
    private Animator animator;
    private PlayerController plac;
    public Vector3 a;

    void Awake() {
        animator = GetComponent<Animator>();
        plac = GetComponentInParent<PlayerController>();
    }

    void OnAnimatorMove()
    {
        SendMessageUpwards("OnUpdateRM", animator.deltaPosition);

    }

    public void ResetTrigger(string triggerName) {
        animator.ResetTrigger(triggerName);
    }

    //TODO : 暂时消除攻击动画播放时缺失事件的错误提示
    void ClearSignalAttack()
    {

    }

    void OnAnimatorIK()
    {
        if (plac.leftIsShield)
        {
            if (animator.GetBool("defense") == false)
            {
                Transform lefLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
                lefLowerArm.localEulerAngles += a;
                animator.SetBoneLocalRotation(HumanBodyBones.LeftLowerArm, Quaternion.Euler(lefLowerArm.localEulerAngles));
            }
        }
    }
}
