using UnityEngine;

public class CharacterSelectionScript : MonoBehaviour
{
   public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
