using Unity.VisualScripting;
using UnityEngine;

public class FruitController : MonoBehaviour
{
    private PlayerInfo playerInfo;
    private Animator fruitAnimator;
    public AudioClip collectedSound;
    private AudioSource fruitAudioSource; //Interfaz encargada de producir el sonido

    private void Awake()
    {
        fruitAnimator = GetComponent<Animator>();//Recuperación del componente ya creado en el gameobject padre
        fruitAudioSource = this.transform.AddComponent<AudioSource>();//Creamos el componente por código en el objeto
        //Llamado al scriptable object
        playerInfo = Resources.Load<PlayerInfo>("PlayerInfo");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))//Compara si está tocando al jugador mediante la identificación del tag
        {
            playerInfo.score += 1; //Incrementa la cantidad de frutas recolectadas en 1
            //Encargado de cambiar la animación
            fruitAnimator.SetBool("collected", true);
            fruitAudioSource.PlayOneShot(collectedSound, 1f);//Reproduce el sonido una sola vez
            Destroy(this.gameObject, 2f);//El segundo parámetro es cuánto tiempo tarda en destruirse el objeto, en este caso 1 segundo
        }
    }

    private void OnDestroy()
    {
        fruitAudioSource.PlayOneShot(collectedSound, 1f);//Esta línea fue copiada en la parte de arriba.
    }
}
