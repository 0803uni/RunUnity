using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyStatus : MobStatus
{
    NavMeshAgent _agent;

    protected override void Start()
    {
        // 基本クラス（MobStatusクラス）のStart()メソッドを呼び出しています
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // agent.velocity.magnitudeでエネミーの速度を計算している
        // 速度が0.01m/sより大きくなったら、walkアニメーションに移行するように
        // Animator Controllerで設定されている
        // 個人的には、EnemyMoveクラスでよいのでは？
        //animator.SetFloat("MoveSpeed", _agent.velocity.magnitude);
    }

    protected override void OnDie()
    {
        // 基本クラス（MobStatusクラス）のOnDie()メソッドを呼び出しています
        base.OnDie();

        StartCoroutine(DestroyCoroutine());
    }

    // 3秒後に死んでしまう
    IEnumerator DestroyCoroutine()
    {
        
        
            yield return new WaitForSeconds(3);
            // 3秒間待った後に実行される
            Destroy(gameObject);
        
    }
}