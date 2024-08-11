using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startinghealth;
    public GameObject gameoverimage;
    public float currenthealth;
    public Animator anim;


    private void Start()
    {
        Time.timeScale = 1f;
        gameoverimage.SetActive(false);
    }
    private void Awake()
    {
        
        currenthealth = startinghealth;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currenthealth =Mathf.Clamp(currenthealth - _damage,0,startinghealth);

        if (currenthealth > 0)
        {
            anim.SetTrigger("hurt");
        }
        else
        {
            anim.SetTrigger("die");
            GetComponent<PlayerMovement>().enabled = false;
    
        }

    }

    public void TakeHealth(float _health)
    {
        currenthealth = Mathf.Clamp(currenthealth + _health, 0, startinghealth);
    }

    public void timetravel()
    {
        gameoverimage.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameQuit()
    {
        Application.Quit(); 
    }

    public void Restart(int n)
    {
        // Reload the current scene
        SceneManager.LoadScene(n);
    }

}
