using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Mob（動くオブジェクト、MovingObjectの略）
// の状態管理スクリプト
public abstract class MobStatus : MonoBehaviour
{
    protected enum StateEnum
    {
        Normal, // 通常時
        Attack, // 攻撃中
        Die     // 死亡時
    }

    // 移動可能かどうか
    public bool IsMovable => StateEnum.Normal == _state;

    // 攻撃可能かどうか
    public bool IsAttackable => StateEnum.Normal == _state;

    // ライフ最大値を返す
    public float LifeMax => lifeMax;

    // ライフの値を返す
    public float Life => _life;

    // ライフ最大値
    [SerializeField] private float lifeMax = 10;
    protected Animator _animator;
    // Mobの状態
    protected StateEnum _state = StateEnum.Normal;
    // 現在のライフ値（ヒットポイント）
    private float _life;

    protected virtual void Start()
    {
        // 初期状態はライフ満タン
        _life = lifeMax;
        // 自身の子オブジェクトから取得
        _animator = GetComponentInChildren<Animator>();

        // ライフゲージの表示開始
        //LifeGaugeContainer.Instance.Add(this);
    }

    // キャラクターが倒れた時の処理を記述
    // 派生クラスで実装
    protected virtual void OnDie()
    {
        // ライフゲージの表示終了
        //LifeGaugeContainer.Instance.Remove(this);
    }

    // 指定値のダメージを受けるメソッド
    public void Damage(int damagePoint)
    {
        // 死んでいればメソッドから抜ける
        if (_state == StateEnum.Die) return;

        // ライフをダメージポイント分減らす
        _life -= damagePoint;

        // ライフ減少後に生きていればメソッドから抜ける
        if (_life > 0) return;

        _state = StateEnum.Die;
       // _animator.SetTrigger("Die");

        OnDie();
    }

    // 可能であれば攻撃中の状態に遷移するメソッド
    public void GoToAttackStateIfPossible()
    {
        if (!IsAttackable) return;

        _state = StateEnum.Attack;
        _animator.SetTrigger("Attack");

        if (IsAttackable)
        {
            _state = StateEnum.Attack;
            _animator.SetTrigger("Attack");
        }
    }

    // 可能であればNormalの状態に遷移するメソッド
    public void GoToNormalStateIfPossible()
    {
        if (_state == StateEnum.Die) return;

        _state = StateEnum.Normal;
    }
}
