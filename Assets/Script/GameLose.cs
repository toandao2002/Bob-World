using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLose : BasePopup
{
    
    public ButtonEffect Restart;
    public ButtonEffect Home;
    
    private void OnEnable()
    {
        base.OnEnable();
        
    }
    
    public void show()
    {
        gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        Restart.onClick.AddListener(restart);
        Home.onClick.AddListener(home);
    }
    void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    void home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
