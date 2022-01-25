using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    [Tooltip("unitychan")]
    private GameObject player;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        // NavMeshAgentを保持しておく
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //岩がY軸に対して１秒間に-500000回転させてる
        transform.Rotate(new Vector3(-500000, -500000) * Time.deltaTime);
        // プレイヤーを目指して進む
        navMeshAgent.destination = player.transform.position;
    }
}