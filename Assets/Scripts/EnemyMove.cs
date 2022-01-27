using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof)(EnemyStatus))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;
    private NavMeshAgent agent;

    private EnemyStatus _stetus;
    // [Tooltip("unitychan")]
     // private GameObject player;

    private NavMeshAgent _agent;

    
    void Start()
    {
        // NavMeshAgentを保持しておく
        _agent = GetComponent<NavMeshAgent>();
        _stetus = GetComponent<EnemyStatus>();
    }

    
    void Update()
    {
        //岩がY軸に対して１秒間に-500000回転させてる
        transform.Rotate(new Vector3(-500000, -500000) * Time.deltaTime);
        //// プレイヤーを目指して進む
        //_agent.destination = playerController.transform.position;
    }
    public void OnDetectObject(Collider collider)
    {
        // プレイヤーを目指して進む
        _agent.destination = playerController.transform.position;
        //if(!_agent.IsMovable)
        //{
        //    _agent.isStopped = true;
        //    return;
        //}
    }
}