using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerStatus : MobStatus
{
    
    [SerializeField]
    DataKeep data;
    protected override void OnDie()
    {
        base.OnDie();

        StartCoroutine(GoToGameOverCoroutine());
    }

    private IEnumerator GoToGameOverCoroutine()
    {
        
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("ResultScene");
}

}
