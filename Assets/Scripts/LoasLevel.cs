using UnityEngine;
using UnityEngine.SceneManagement;
public class LoasLevel : MonoBehaviour
{
    public int indexLevel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene()
     
    {
        SceneManager.LoadScene(indexLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
