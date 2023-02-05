using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
