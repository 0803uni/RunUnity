﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3;
    [SerializeField]
    private float JumpPower = 3;

    private CharacterController characterController;

    private Transform _transform;
    //キャラクターの移動情報
    private Vector3 moveVelocity;



    public object CrossPlatformInputManager { get; private set; }

    void Start()
    {
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
        //入力軸による、移動処理
        moveVelocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        moveVelocity.y = Input.GetAxis("Vertical") * moveSpeed;

        //移動方向に向く
        _transform.LookAt( _transform.position + new Vector3
            (moveVelocity.x, 0, moveVelocity.z));

        if(characterController.isGrounded)
        {
            if(Input.GetButtonDown("Jump"))
            {
                //ジャンプの際に上方向に移動させる
                moveVelocity.y = JumpPower;
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