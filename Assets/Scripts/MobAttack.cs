using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobStatus))]
public class MobAttack : MonoBehaviour
{
    MobStatus _status;
    void Start()
    {
        _status = GetComponent<MobStatus>();
    }
    // 攻撃可能なら攻撃する
    public void AttackIfPossible()
    {
        if (_status.IsAttackable)
        {
            _status.GoToAttackStateIfPossible();
        }

    }
    // 攻撃対象が範囲に入った場合
    public void OnAtttackRangeEnter(Collider collider)
    {
        AttackIfPossible();
    }

    [SerializeField]
    Collider attackCollider;
    // 攻撃開始時（コライダーをイネーブル（有効）にします）
    [SerializeField]
    //武器を振る音
    private AudioSource swingSound;

    public void OnAttackStart()
    {
        attackCollider.enabled = true;

        if (swingSound != null)
        {
            //武器を振る音の再生をランダムに変化させ、毎回少し違う音出るようにしている
            swingSound.pitch = Random.Range(0.7f, 1.3f);
            swingSound.Play();
        }
    }
    // attackColliderがヒットしたとき
    public void OnHitAttack(Collider collider)
    {
        // 衝突（攻撃）相手のMovbStatusコンポーネントの取得
        MobStatus targetMob = collider.GetComponent<MobStatus>();
        //衝突相手にMobStatusコンポーネントがアタッチされていないとき
        //メソッドを抜ける
        if (targetMob == null)
        {
            return;
        }
        //衝突（攻撃）相手のMobStatusのDamageメソッドを呼び出す（相手にダメージを与える）
        targetMob.Damage(1);
    }

    //攻撃終了時に呼び出されている
    public void OnAttackFinished()
    {
        attackCollider.enabled = false;
        StartCoroutine(CooldownCoroutine());
    }
    // 攻撃後に一呼吸置く時間
    [SerializeField]
    float attackColldownTime = 0.5f;

    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(attackColldownTime);
        _status.GoToNormalStateIfPossible();

    }
}
