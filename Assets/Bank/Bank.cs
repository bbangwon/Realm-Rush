using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    
    [SerializeField] int currentBalance;
    public int CurrentBalance => currentBalance;

    private void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        //실수로 음수를 입금하는 것을 방지하기 위해 절대값을 취함
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        //실수로 음수를 출금하는 것을 방지하기 위해 절대값을 취함
        currentBalance -= Mathf.Abs(amount);

        if(currentBalance < 0)
        {
            ReloadScene();
        }
    }

    void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
