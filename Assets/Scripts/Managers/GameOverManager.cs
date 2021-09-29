using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;

    //ditambahkan agar animasi game over tidak terus ke trigger ulang
    private bool gameOver = false;

    Animator anim;                          
    float restartTimer;                    

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            //Debug.Log("Game over");

            if (!gameOver)
            {
                gameOver = true;
                anim.SetTrigger("GameOver");
            }

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
    }
}