using UnityEngine;

public class GameUI : MonoBehaviour
{
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
