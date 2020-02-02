using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
	private float m_TimeScaleRef = 1f;
    private bool isPaused = false;

    private void Start()
    {
        Time.timeScale = 1f;
        pauseMenu.gameObject.SetActive(false);
    }

    private void MenuOn ()
    {
        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        isPaused = true;
    }


    public void MenuOff ()
    {
        Time.timeScale = m_TimeScaleRef;
        pauseMenu.SetActive(false);
        isPaused = false;
    }

	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused == true)
            {
                MenuOff();
            }
            else
            {
                MenuOn();
            }
        }

    }

}
