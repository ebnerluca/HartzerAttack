using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float maxSpecial = 100f;
    private float health;
    private float special;

    public float specialAbilityLoadingRate = 2.5f;

    public bool specialAbilityActive = false;
    private bool isDying = false;
    public float flinchingTime = 0.2f;


    private StatusBar healthBar;
    private StatusBar specialBar;
    public CharacterManager characterManager;

    private void Awake()
    {
        health = maxHealth;
        special = maxSpecial;

    }

    void Start()
    {

        if (GameObject.FindGameObjectWithTag("HealthBar") != null)
        {
            healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<StatusBar>();
            healthBar.Initialize(health, maxHealth);
        }
        else
        {
            Debug.LogError("[PlayerStats]: healthBar not found. Script disabled!");
            enabled = false;
        }

        if (GameObject.FindGameObjectWithTag("SpecialBar") != null)
        {
            specialBar = GameObject.FindGameObjectWithTag("SpecialBar").GetComponent<StatusBar>();
            specialBar.Initialize(special, maxSpecial);
        }
        else
        {
            Debug.LogError("[PlayerStats]: specialBar not found. Script disabled!");
            enabled = false;
        }
    }

    public void ForceStart()
    {
        Start();
    }

    private void FixedUpdate()
    {
        if (!specialAbilityActive)
        {
            special += specialAbilityLoadingRate * Time.fixedDeltaTime;
            special = Mathf.Clamp(special, 0f, maxSpecial);
        }
    }

    private void Update()
    {

        healthBar.SetValue(health);
        specialBar.SetValue(special);

        if(health <= 0f && !isDying)
        {
            StartCoroutine(Die());
        }
    }

    public void UpdateStats(float newMaxHealth, float newMaxSpecial, float newSpecialAbilityLoadingRate)
    {
        maxHealth = newMaxHealth;
        maxSpecial = newMaxSpecial;
        SetHealth(Mathf.Clamp(health, 0f, maxHealth));
        SetSpecial(Mathf.Clamp(special, 0f, maxSpecial));

        healthBar.SetMaxValue(maxHealth);
        specialBar.SetMaxValue(maxSpecial);

        specialAbilityLoadingRate = newSpecialAbilityLoadingRate;
    }

    private IEnumerator Die()
    {
        isDying = true;

        StartCoroutine(characterManager.Flinch(1.0f));
        gameObject.GetComponent<PlayerMovement>().enabled = false;

        yield return new WaitForSeconds(1.0f);

        GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().RespawnPlayer(gameObject);
        ResetStats();

        isDying = false;

    }

    private void ResetStats()
    {
        health = maxHealth;
        special = maxSpecial;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health > 0f)
        {
            StartCoroutine(characterManager.Flinch(flinchingTime));
        }
    }

    public bool PaySpecial(float cost)
    {
        if(cost <= special)
        {
            special -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void IncreaseSpecial(float value)
    {
        special += value;
        special = Mathf.Clamp(special, 0f, maxSpecial);
    }

    public void IncreaseHealth(float value)
    {
        health += value;
        health = Mathf.Clamp(health, 0f, maxHealth);
    }

    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetSpecial(float newSpecial)
    {
        special = newSpecial;
    }

    public float GetSpecial()
    {
        return special;
    }

}
