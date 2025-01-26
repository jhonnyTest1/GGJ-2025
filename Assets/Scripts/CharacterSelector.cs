using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    
    public GameObject menu;
    public GameObject egg;
    public GameObject teethbrush;
    public GameObject brick;
    public GameObject coffe;
    public GameObject lapm;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        Time.timeScale = 0f;
        menu.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayTime()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }
    public void ViewEgg() 
    {
        egg.SetActive(true);
    }
    public void ViewTeethBrush()
    { 
        teethbrush.SetActive(true);
    }
    public void ViewBrick()
    {
        brick.SetActive(true);
    }
    public void ViewCoffe()
    {
        coffe.SetActive(true); 
    }
    public void ViewLamp()
    {
        lapm.SetActive(true);
    }
}
