using UnityEngine;

public class Menu : MonoBehaviour
{
    public void RestartGame()
    {
        GameObject.Find("Player_prefab").transform.position = new Vector3(-2, 3.1f, 0);
        transform.Find("End_UI").gameObject.SetActive(false);
        Debug.Log("Restart!");
    }

    public void Exit()
    {
        Debug.Log("Exit!");
        Application.Quit();
    }
}
