using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlesAndIntroControl : MonoBehaviour
{
    
    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            StartCoroutine(SecondsTimerCoroutine());
        }
    }

    private IEnumerator SecondsTimerCoroutine()
    {
        yield return new WaitForSeconds(30f);
        SceneManager.LoadScene(0);
    }
}
