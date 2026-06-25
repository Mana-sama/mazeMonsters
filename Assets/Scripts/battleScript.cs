using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class battleScript : MonoBehaviour
{
    public float waitSeconds = 7;

    private Animator battle;

    public Text BattleText;
    public GameObject ButtonCover;

    public GameObject HpMenu;
    public GameObject ItemMenu;

    private int PHealth = 200;
    public Text PHealthText;
    private int PAtk = 15;

    private int EHealth = 45;
    public Text EHealthText;
    private int EAtk = 10;

    public GameObject Luck1;
    public GameObject Luck2;
    public GameObject Fortune;

    public Button AttackButton;
    public Button FleeButtonUI; // НОВЕ: Кнопка втечі для КД

    public Transform EnemyTransform;

    private bool battleEnded = false;
    private bool canFlee = true; // НОВЕ: Перевірка КД втечі

    void Start()
    {
        battle = GetComponent<Animator>();
        UpdatePHealthText();
        UpdateEHealthText();

        StartCoroutine(EnemyAttackLoop());
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
        if (battleEnded || !AttackButton.interactable) return;
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        AttackButton.interactable = false;

        Vector3 startPos = transform.position;
        Vector3 targetPos = startPos + new Vector3(6, 0, 0);
        float duration = 0.5f;
        float elapsed = 0;

        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPos;

        EHealth -= PAtk;
        UpdateEHealthText();

        yield return new WaitForSeconds(0.2f);

        elapsed = 0;
        while (elapsed < duration)
        {
            transform.position = Vector3.Lerp(targetPos, startPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = startPos;

        if (EHealth <= 0)
        {
            battleEnded = true;
            if (BattleText) BattleText.text = "You won!";
            if (ButtonCover) ButtonCover.SetActive(true);

            // ЗБЕРЕЖЕННЯ: Позначаємо поточного ворога як мертвого
            string currentEnemy = PlayerPrefs.GetString("CurrentEnemy", "");
            if (!string.IsNullOrEmpty(currentEnemy))
            {
                PlayerPrefs.SetInt(currentEnemy + "_Dead", 1);
                PlayerPrefs.Save();
            }

            StartCoroutine(WinSequence());
        }
        else
        {
            // КД АТАКИ ГРАВЦЯ (ЗБІЛЬШЕНО)
            yield return new WaitForSeconds(2f);
            if (!battleEnded) AttackButton.interactable = true;
        }
    }

    IEnumerator WinSequence()
    {
        yield return new WaitForSeconds(4f);
        // Завантажуємо попередню сцену замість хардкоду
        SceneManager.LoadScene(PlayerPrefs.GetString("LastScene", "ZONE0"));
    }

    IEnumerator EnemyAttackLoop()
    {
        while (!battleEnded)
        {
            // КД АТАКИ ВОРОГА (ЗМЕНШЕНО)
            float waitTime = Random.Range(2f, 4f);
            yield return new WaitForSeconds(waitTime);

            if (!battleEnded)
            {
                StartCoroutine(EnemyAttackAction());
            }
        }
    }

    IEnumerator EnemyAttackAction()
    {
        if (EnemyTransform != null)
        {
            Vector3 startPos = EnemyTransform.position;
            Vector3 targetPos = startPos + new Vector3(-6, 0, 0);
            float duration = 0.5f;
            float elapsed = 0;

            while (elapsed < duration)
            {
                EnemyTransform.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            EnemyTransform.position = targetPos;

            TakeDmg();

            yield return new WaitForSeconds(0.2f);

            elapsed = 0;
            while (elapsed < duration)
            {
                EnemyTransform.position = Vector3.Lerp(targetPos, startPos, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            EnemyTransform.position = startPos;
        }
        else
        {
            TakeDmg();
        }
    }

    public void FleeButton()
    {
        if (battleEnded || !canFlee) return;
        StartCoroutine(Flee());
    }

    IEnumerator Flee()
    {
        canFlee = false;
        if (FleeButtonUI != null) FleeButtonUI.interactable = false;

        int random = Random.Range(1, 3);

        if (random == 1)
        {
            battleEnded = true;
            if (BattleText) BattleText.text = "You escaped!";
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(PlayerPrefs.GetString("LastScene", "ZONE0"));
        }
        else
        {
            if (BattleText) BattleText.text = "You failed to escape.";

            // Запускаємо КД на 20 секунд перед тим, як знову можна буде спробувати втекти
            yield return new WaitForSeconds(20f);

            if (!battleEnded)
            {
                canFlee = true;
                if (FleeButtonUI != null) FleeButtonUI.interactable = true;
                if (BattleText) BattleText.text = "You can try to flee again.";
            }
        }
    }

    public void TakeDmg()
    {
        PHealth -= EAtk;
        UpdatePHealthText();

        if (PHealth <= 0 && !battleEnded)
        {
            battleEnded = true;
            if (BattleText) BattleText.text = "You lost!";
            if (battle != null) battle.SetBool("isDead", true);

            StartCoroutine(LoseSequence());
        }
        else if (!battleEnded)
        {
            StartCoroutine(HurtAnim());
        }
    }

    IEnumerator HurtAnim()
    {
        if (battle != null) battle.SetBool("isHurt", true);
        yield return new WaitForSeconds(2.3f);
        if (battle != null) battle.SetBool("isHurt", false);
    }

    IEnumerator LoseSequence()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("GameOver");
    }

    public void ChangeToItem() { HpMenu.SetActive(false); ItemMenu.SetActive(true); }
    public void ChangeToHp() { HpMenu.SetActive(true); ItemMenu.SetActive(false); }

    public void useLuck1() { Heal(50, Luck1); }
    public void useLuck2() { Heal(50, Luck2); }
    public void useFortune() { Heal(150, Fortune); }

    private void Heal(int amount, GameObject itemObj)
    {
        if (PHealth >= 200) return;
        PHealth += amount;
        if (PHealth > 200) PHealth = 200;
        UpdatePHealthText();
        if (itemObj != null) itemObj.SetActive(false);
    }
}