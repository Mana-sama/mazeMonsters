using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class battleScript : MonoBehaviour
{
    public float waitSeconds = 7;


    private float timer;
    private Animator battle;

    public Text BattleText;
    public GameObject ButtonCover;

    public GameObject HpMenu;
    public GameObject ItemMenu;

    private int PHealth = 200;
    public Text PHealthText;
    private int PAtk = 15;
    bool isDead;

    private int EHealth = 45;
    public Text EHealthText;
    private int EAtk = 10;

    public GameObject Luck1;
    public GameObject Luck2;
    public GameObject Fortune;

    public Button AttackButton;


    void Start()
    {
        battle = GetComponent<Animator>();
        UpdatePHealthText();
        UpdateEHealthText();
       // AttackButton.interactable = true;
        // AttackButton.gameObject.SetActive(false);
    }

    void Update()
    {
    }

    private void UpdatePHealthText()
    {
        if (PHealthText != null) PHealthText.text = PHealth + "/ 200";
    }

    private void UpdateEHealthText()
    {
        if (EHealthText != null) EHealthText.text = EHealth + "/ 45";
    }

    public void Attack()
    {
       // StartCoroutine(AttackWait());
        StartCoroutine(AttackRoutine());
    }

    /*
    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(3);
        AttackButton.interactable = false;
    }
    
    */
    IEnumerator AttackRoutine()
    {

        // 1. ???
        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + new Vector3(6, 0, 0);
        float duration = 0.5f;
        float elapsed = 0;

        while (elapsed < duration) // ??????
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        // 2. ????
        EHealth = EHealth - PAtk;
        UpdateEHealthText();

        yield return new WaitForSeconds(0.2f);

        elapsed = 0;
        while (elapsed < duration) // ?????
        {
            transform.position = Vector3.Lerp(targetPos, startPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;

        if (EHealth <= 0)
        {
            if (BattleText) BattleText.text = "You won!";
            if (ButtonCover) ButtonCover.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("ZONE0"); //after save system is made change it to current zone
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(TakeDmgRoutine());
        }

        /*
        yield return new WaitForSeconds(4);
        AttackButton.interactable = false;
        */
       // AttackButton.interactable = true;

    }

    public void FleeButton()
    {
        Flee();
    }
    IEnumerator Flee()
    {
        int random = Random.Range(1, 3);

        if (random == 1)
        {
            SceneManager.LoadScene("ZONE0");  //after save system is made change it to current zone
            if (BattleText) BattleText.text = "You escaped!";
        }

        else
        {
            if (BattleText) BattleText.text = "You failed to escape.";
            yield return new WaitForSeconds(waitSeconds);
            if (BattleText) BattleText.text = "Purification in progress...";

        }

    }



    public void TakeDmg()
    {
        StartCoroutine(TakeDmgRoutine());
    }

    IEnumerator TakeDmgRoutine()
    {
        PHealth = PHealth - EAtk;
        UpdatePHealthText();

        if (PHealth <= 0)
        {
            if (BattleText) BattleText.text = "You lost!";
            if (battle != null) battle.SetBool("isDead", true);

            yield return new WaitForSeconds(4f);
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            if (battle != null) battle.SetBool("isHurt", true);

            yield return new WaitForSeconds(2.3f);

            if (battle != null) battle.SetBool("isHurt", false);
        }
    }



    ///////////////////////// buttons below

public void ChangeToItem()
    {
        HpMenu.gameObject.SetActive(false);
        ItemMenu.gameObject.SetActive(true);

    }

    public void ChangeToHp()
    {
        HpMenu.gameObject.SetActive(true);
        ItemMenu.gameObject.SetActive(false);

    }

    ////////////////////////// heal below

    public void useLuck1()
    {
        if (PHealth >= 200)
        {
            PHealth = 200;
            UpdatePHealthText();
        }

        if (PHealth >= 151)
        {
            PHealth = 200;
            UpdatePHealthText();
            Luck1.gameObject.SetActive(false);
        }

        else
        {
        PHealth += 50;
        UpdatePHealthText();
        Luck1.gameObject.SetActive(false);

        }

    }

    public void useLuck2()
    {
        if (PHealth >= 200)
        {
            PHealth = 200;
            UpdatePHealthText();
        }

        if (PHealth >= 151)
        {
            PHealth = 200;
            UpdatePHealthText();
            Luck2.gameObject.SetActive(false);
        }

        else
        {
            PHealth += 50;
            UpdatePHealthText();
            Luck2.gameObject.SetActive(false);

        }
    }

    public void useFortune()
    {
        if (PHealth >= 200)
        {
            PHealth = 200;
            UpdatePHealthText();
        }

        if(PHealth >= 51)
        {
            PHealth = 200;
            UpdatePHealthText();
            Fortune.gameObject.SetActive(false);
        }

        else
        {
        PHealth += 150;
        UpdatePHealthText();
        Fortune.gameObject.SetActive(false);

        }

    }

    /////////////////////////////

}