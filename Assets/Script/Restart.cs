using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    public void modoru()
    {
        SceneManager.LoadScene("startScene");
        Debug.Log("最初に戻る");
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;

        UnityEngine.Application.Quit();
        Debug.Log("画面消した");
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }

    }

    public void maingo()
    {
        SceneManager.LoadScene("mainScene");
    }
}
