using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 3;
    [SerializeField]
    private float JumpPower = 3;


    [SerializeField]
    private Animator animator;


    private CharacterController characterController;

    private Transform _transform;
    //キャラクターの移動情報
    private Vector3 moveVelocity;



    public object CrossPlatformInputManager { get; private set; }

    void Start()
    {
        animator = GetComponent<Animator>();
        //ここで重力の値を変更している
        Physics.gravity = new Vector3(0, -80, 0);

        //マイフレームアクセスするので、負荷を下げるためにキャッシュしておく
        characterController = GetComponent<CharacterController>();
        //Trasformもキャッシュしすると少し負荷を下がる
        _transform = transform;
    }

    private bool IsGrounded
    {
        get
        {

            var ray = new Ray(_transform.position + new Vector3(0, 0.1f), Vector3.down);
            var raycastHits = new RaycastHit[1];
            var hitCount = Physics.RaycastNonAlloc(ray, raycastHits, 0.2f);
            return hitCount >= 1;
        }
    }
    void Update()
    {
        animator.SetFloat
            ("MoveSpeed", new Vector3(moveVelocity.x, 0, moveVelocity.z).magnitude);

        animator.SetFloat("MoveSpeed", 0f);
        animator.SetFloat("Direciton", 0f);
        animator.SetBool("JumpPower", false);
        animator.SetBool("Rest", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetFloat("MoveSpeed", 1.2f);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var Speed = animator.GetFloat("MoveSpeed");
            animator.SetFloat("MoveSpeed", Speed * 100);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var Distance = animator.GetFloat("Direciton");
            animator.SetFloat("Direciton", 120f);
        }


        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    animator.SetFloat("MoveSpeed", -1.2f);
        //}

        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    var Distance = animator.GetFloat("Direction");
        //    animator.SetFloat("Direction", -0.2f);
        //}

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (animator.GetFloat("MoveSpeed") == 0f)
        //    {
        //        animator.GetBool("Rest,true");

        //    }
        //    else
        //    {
        //        animator.SetBool("JumpPower", true);
        //    }
        //}


        //    //入力軸による、移動処理
        moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVelocity.y = Input.GetAxis("Vertical") * moveSpeed;

        //    //移動方向に向く
        _transform.LookAt(_transform.position + new Vector3
            (moveVelocity.x, 0, moveVelocity.z));

        if (characterController.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                //ジャンプの際に上方向に移動させる
                moveVelocity.y = JumpPower;

                if (animator.GetFloat("MoveSpeed") == 0f)
                {
                    animator.GetBool("Rest,true");

                }
                else
                {
                    animator.SetBool("JumpPower", true);
                }
            }
        }
        else
        {
            //重力によって加速
            moveVelocity.y += Physics.gravity.y * Time.deltaTime;
        }
        characterController.Move(moveVelocity * Time.deltaTime);
    }

}

