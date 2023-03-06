using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : BasePopup  
{
    public ButtonEffect Continue;
    public ButtonEffect Restart;
    public ButtonEffect Home;
    public ButtonEffect Shop;

    // Start is called before the first frame update
    void Start()
    {
        Continue.onClick.AddListener(ContinueGame);
        Restart.onClick.AddListener(restart);
        Home.onClick.AddListener(home);
        Shop.onClick.AddListener(shop);
    }
    private void OnEnable()
    {
        base.OnEnable();
        
    }
    void ContinueGame()
    {
        CanvasManage.Instance.HidePopup(PopupName.Pause);
        
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
    void shop()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
