using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossDialoguePuzzle : MonoBehaviour
{
    public static BossDialoguePuzzle Instance;
    public GameObject ScrapBoss;
    public GameObject FixBoss;
    public bool ScrapHasRun;
    public bool FixHasRun;
    public int check = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ScrapHasRun = false;
        FixHasRun = false;
        ScrapBoss.SetActive(false);
        FixBoss.SetActive(false);
    }
    private void OnTriggerStay(Collider other)
    {

        if (check == 1 && ScrapHasRun == false)
        {
            Scrap();
            ScrapHasRun = true;
        }
        else if (check == 2 && FixHasRun == false)
        {
            Fix();
            FixHasRun = true;
        }
    }
    private void Scrap()
    {
        ScrapBoss.SetActive(true);
        ThirdPersonMovement.Instance.FreezePlayer();
    }
    private void Fix()
    {
        FixBoss.SetActive(true);
        ThirdPersonMovement.Instance.FreezePlayer();
    }
    public void CheckForScrap()
    {
        check = 1;
    }
    public void CheckForFix()
    {
        check = 2;
    }
}
