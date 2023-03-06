using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonLevel : MonoBehaviour
{
    public GameObject Lock;
    public int level;
    ButtonEffect buttonEffect;
    public TMP_Text TxtLevel ;
    // Start is called before the first frame update
    void Start()
    {
        buttonEffect = GetComponent<ButtonEffect>();
        buttonEffect.onClick.AddListener(PlayLevel);
        
    }
    private void OnEnable()
    {
        TxtLevel.text = level.ToString();
        if (level <= DataPlayer.GetdataInt(DataPlayer.Level)+1)
        {
            Lock.SetActive(false);
        }
        else
        {
            Lock.SetActive(true);
        }
    
    }
        
    
    void PlayLevel()
    {
        if (level <= DataPlayer.GetdataInt(DataPlayer.Level) + 1)
        {
            DataPlayer.SetDataInt(DataPlayer.LevelPlayCurrent, level-1);
            SceneManager.LoadScene("Level" + level.ToString());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
      
}
