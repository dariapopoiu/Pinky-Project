using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    private static int _nextLevelIndex = 1;/// contorul nr de nivele
    /// </summary>
    private Enemy[] _enemies;/// un vector cu toti dusmanii


    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }


    void Update()
    {
        foreach (Enemy enemy in _enemies)/// pt fiecare dusman din vectorul de dusmani
        {
            if (enemy != null)
                return;
        }

        Debug.Log("You killed all enemies");

        _nextLevelIndex++;//mergem la urm nivel
        string nextLevelName = "Level" + _nextLevelIndex; ///ca sa schimbam nivelurile
        SceneManager.LoadScene(nextLevelName);
    }
}