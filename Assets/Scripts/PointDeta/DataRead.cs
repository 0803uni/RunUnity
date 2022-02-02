using UnityEngine;

public class DataRead : MonoBehaviour
{
    [SerializeField]
    DataKeep data;

    void Start()
    {
        Debug.Log(data.score);
    }
}
