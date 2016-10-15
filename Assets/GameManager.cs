using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]private Text _infoText;
    [SerializeField]private RuntimeAnimatorController _endIdle;

    void Awake()
    {
        StartCoroutine(ShowInstructions());
    }

    private void StartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        StartCoroutine(RestartGame());
    }

    IEnumerator ShowInstructions()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        RuntimeAnimatorController run = player.GetComponent<Animator>().runtimeAnimatorController;
        player.GetComponent<Animator>().runtimeAnimatorController = _endIdle;
        player.GetComponent<FatnessController>().enabled = false;
        _infoText.enabled = true;
        _infoText.text = "Collect as much food as you can, but don't get too skinny! Use A/D or Left/Right Arrow to turn!";
        yield return new WaitForSeconds(6);
        _infoText.enabled = false;
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<PlayerPCInput>().enabled = true;
        player.GetComponent<FatnessController>().enabled = true;
        player.GetComponent<Animator>().runtimeAnimatorController = run;
    }

    IEnumerator RestartGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<PlayerPCInput>().enabled = false;
        player.GetComponent<Animator>().runtimeAnimatorController = _endIdle;
        _infoText.enabled = true;
        _infoText.text = "Your score is: " + player.GetComponent<PlayerScore>().playerScore;
        yield return new WaitForSeconds(5);
        _infoText.text = "Press any key to restart!";
        yield return StartCoroutine(WaitForAnyKeyDown());
        StartGame();
    }

    IEnumerator WaitForAnyKeyDown()
    {
        while (!Input.anyKeyDown)
            yield return null;
    }
}
