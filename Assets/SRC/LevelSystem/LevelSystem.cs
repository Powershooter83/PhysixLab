using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private GameObject portal;
    [SerializeField] private GameObject target;
    [SerializeField] private List<Level> Levels;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI levelTypeText;
    [SerializeField] private TextMeshProUGUI currentLevel;
    [SerializeField] private GameObject fireworks;

    private Level activeLevel;
    private int currentLevelIndex = 0;

    public void Start()
    {
        activeLevel = Levels[currentLevelIndex];
        setupNewLevel();
    }


    public String getCurrentLevelName()
    {
        return currentLevelIndex.ToString();
    }

    public Level getActiveLevel()
    {
        return activeLevel;
    }

    public void loadNextLevel()
    {
        StartCoroutine(ActivateTemporary());
        currentLevelIndex++;

        if (currentLevelIndex >= Levels.Count)
        {
            win();
            return;

        }
        
        activeLevel = Levels[currentLevelIndex];
        setupNewLevel();
    }

    IEnumerator ActivateTemporary()
    {
        fireworks.SetActive(true);
        yield return new WaitForSeconds(4f);
        fireworks.SetActive(false);
    }

    public bool isBlocked()
    {
        return fireworks.activeSelf;
    }
    
    public void win()
    {

        SceneManager.LoadScene("Menu");

    }

    public void setupNewLevel()
    {
        portal.transform.position = activeLevel.portalLocation;
        target.transform.position = activeLevel.targetLocation;
        levelText.text = activeLevel.levelText;
        currentLevel.text = (currentLevelIndex + 1).ToString();

        switch (activeLevel.levelType)
        {
            case LevelType.Abschussgeschwindigkeit:
                levelTypeText.text = "Launch velocity in m/s";
                break;
            case LevelType.Abschusshoehe:
                levelTypeText.text = "Launch height in m";
                break;
            case LevelType.Abschusswinkel:
                levelTypeText.text = "Launch angle to the horizontal in degrees";
                break;
            case LevelType.TargetVerschieben:
                levelTypeText.text = "Target position in m";
                break;
        }
    }

    public void movePortal(float portalHeight)
    {

        portal.transform.position = activeLevel.portalLocation;
        
        if (portalHeight > 0)
        {
            
            portal.transform.position += new Vector3(0, portalHeight, 0);    
        }
        
    }

    public void moveTarget(float targetLocation)
    {
        target.transform.position = activeLevel.targetLocation;
        if (targetLocation == 0)
        {
            return;
        }

        target.transform.position += new Vector3(0, 0, targetLocation - 1);
    }
}