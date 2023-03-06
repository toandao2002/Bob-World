using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChoseLevel : MonoBehaviour
{
    public ButtonEffect Home;

    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update

    private void Start()
    {
        Home.onClick.AddListener(Hide );
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
