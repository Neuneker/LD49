using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignAnimator : MonoBehaviour
{
    

    public void StartSwing()
    {
        GetComponent<Animator>().SetTrigger("Swing");
    }

    
}
