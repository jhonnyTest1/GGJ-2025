using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] GameObject storeMenu;
    [SerializeField] float stageTime;
    [SerializeField] List<GameObject> weapons;

    private void Start()
    {
        Invoke(nameof(StartGame), 1f);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].GetComponent<IPlayerAttack>().SetStats();
        }
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        float actualTime = 0f;
        while (actualTime < stageTime)
        {
            actualTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        EndOfStages();
        storeMenu.SetActive(true);
    }

    void EndOfStages()
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            weapons[i].GetComponent<IPlayerAttack>().FinishBehaviour();
        }
        Time.timeScale = 0;
    }
}
