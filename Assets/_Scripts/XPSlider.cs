using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPSlider : MonoBehaviour
{
    public static XPSlider Brain;
    
    private int level;
    private int experience;
    private int experienceNeededToLevelUp;

    public Slider levelUpBar;
    public Text currentLevel;

    private void Start()
    {
        level = 0;
        experience = 0;
        experienceNeededToLevelUp = 0;

        levelUpBar.value = experience;
        levelUpBar.maxValue = experienceNeededToLevelUp;
        
       
    }
    
    void Awake()
    {
        if(XPSlider.Brain == null)
        {
            XPSlider.Brain = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            experience += 2;
            levelUpBar.value = experience;
            
          
        }

        if (levelUpBar.value >= levelUpBar.maxValue)
        {
            IncreaseLevel();
        }
    }

    public void AddXP()
    {
        experience += 2;
        levelUpBar.value = experience;
        
    }

    void     IncreaseLevel()
{
    experience = 0;
    levelUpBar.value = experience;

    experienceNeededToLevelUp += 10;
    levelUpBar.maxValue = experienceNeededToLevelUp;

    level += 1;
    currentLevel.text = "LEVEL" + level;
}
}
