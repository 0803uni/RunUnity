using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetGene : MonoBehaviour
{
    private Vector3 targetpos;
    public Text Scretext;
    public static int score = 0;
        void OnCollisonEnter(Collision collison)
    {
        score += 10;
        Scretext.text = string.Format("Socre{0}", score);

        GetComponent<ParticleSystem>().Play();
    }

    public static int getscore()
    {
        return score;
    }
    void Start()
    {
        targetpos = transform.position;
    }

   
    void Update()
    {
        
    }
}
