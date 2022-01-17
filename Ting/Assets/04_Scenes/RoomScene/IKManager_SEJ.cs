using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//카메라가 움직이는 방향대로 캐릭터도 같이 움직이게 한다
public class IKManager_SEJ : MonoBehaviour
{
    public Animator anim;
    public Transform Left;
    public Transform Right;
    public Transform look;
    [Range(0f,1f)]
    public float weightLook = 0.2f;
    public float weightPos = 1;
    public float weightRot = 1;

    private void Start()
    { if(gameObject.name == "Woman")
        { 
            GetComponentInParent<PlayerMoveInG2>().anim = GetComponent<Animator>();
        }
      else
         GetComponentInParent<PlayerMove_Rio>().anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetLookAtWeight(weightLook);
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weightPos);//가중치
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weightPos);//가중치
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weightRot);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, weightRot);

        anim.SetLookAtPosition(look.position);

        //특정 물체를 따라가게 하고 싶다
        anim.SetIKPosition(AvatarIKGoal.LeftHand, Left.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, Right.position);

        //회전

        anim.SetIKRotation(AvatarIKGoal.LeftHand, Left.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, Right.rotation);
    }

}
