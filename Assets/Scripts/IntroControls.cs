using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroControls : MonoBehaviour
{
    [TextArea] public string text;

    [SerializeField] private TMP_Text textToDisplay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroCoro());
    }

    private IEnumerator IntroCoro()
    {
        for (int i = 0; i < text.Length; i++)
        {
            textToDisplay.text += text[i];
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
