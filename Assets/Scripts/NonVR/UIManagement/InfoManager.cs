using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoManager : MonoBehaviour
{

    public GameObject bonePanel;
    public TextMeshProUGUI boneName;
    public TextMeshProUGUI boneGenus;
    public TextMeshProUGUI boneFact;
    public Transform panelLocation;

    public GameObject LoadingScreen;
    public GameObject LoadingRaptor;
    
    bool panelActive;
    bool loadActive = false;

    public float panelTimeRemaining;
    public float loadTimeRemaining = 5;
    //public PlayerShot bullet;


    // Start is called before the first frame update
    void Start()
    {

        bonePanel.SetActive(false);
    }

    public void GetInfo(string name, string genus, string fact)
    {
        boneName.text = name;
        boneGenus.text = genus;
        boneFact.text = fact;
        panelTimeRemaining = 5;
        panelActive = true;
        bonePanel.SetActive(true);
    }
    // Update is called once per frame
    public float timeRemaining;


    

    private void Update()
    {
        /*if (!loadActive)
        {
            StartCoroutine("Loading");
        }*/


        if (panelActive)
        {
            if (panelTimeRemaining > 0)
            {
                //timeRemaining -= Time.deltaTime;
                panelTimeRemaining -= Time.deltaTime;
            }
            else if (panelTimeRemaining < 0)
            {
                panelTimeRemaining = 0;
                bonePanel.SetActive(false);
                panelActive = false;

            }
        }

    }

    IEnumerator LoadingScreenCo()
    {
        loadActive = true;
        LoadingScreen.SetActive(true);
        LoadingRaptor.SetActive(true);

        if (loadTimeRemaining > 0)
        {
            //timeRemaining -= Time.deltaTime;
            loadTimeRemaining -= Time.deltaTime;
        }
        else if (panelTimeRemaining < 0)
        {
            loadTimeRemaining = 0;
            LoadingScreen.SetActive(false);
            LoadingRaptor.SetActive(false);

            panelActive = false;
        }
        loadTimeRemaining = 5;
        yield return true;
    }
}
