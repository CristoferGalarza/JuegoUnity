using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int sceneIndex;
    public GameObject fruits;//
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && fruits.transform.childCount==0)//cuando ya no se tengan hijos, ya no tendré más frutas
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
