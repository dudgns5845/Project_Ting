using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ī�޶� �����̴� ������ ĳ���͵� ���� �����̰� �Ѵ�
public class IKManager_SEJ : MonoBehaviour
{
    public Animator anim;
    Transform Left;
    Transform Right;
    Transform look;
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

    public void Init(Transform l, Transform r, Transform eye)
    {
        Left = l;
        Right = r;
        look = eye;
    }

    // Start is called before the first frame update
    private void OnAnimatorIK(int layerIndex)
    {
        if(Left != null)
        {
            anim.SetLookAtWeight(weightLook);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weightPos);//����ġ
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weightPos);//����ġ
            anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weightRot);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, weightRot);

            anim.SetLookAtPosition(look.position);

            //Ư�� ��ü�� ���󰡰� �ϰ� �ʹ�
            anim.SetIKPosition(AvatarIKGoal.LeftHand, Left.position);
            anim.SetIKPosition(AvatarIKGoal.RightHand, Right.position);

            //ȸ��

            anim.SetIKRotation(AvatarIKGoal.LeftHand, Left.rotation);
            anim.SetIKRotation(AvatarIKGoal.RightHand, Right.rotation);
        }
    }
}
