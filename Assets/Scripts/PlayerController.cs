using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /*Se maneja un controlador diferente par ala parte de la interfaz y para el jugador*/
    public Rigidbody2D rbPlayer;//Permite tener físicas como colisiones o gravedad
    public InputActionAsset input;
    private InputActionMap inputMap;
    private InputAction move;
    public float speed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputMap = input.FindActionMap("Player");//Se busca el mapa de acciones llamado "Player"
        move = inputMap.FindAction("Move");//Se busca la acción llamada "Move"
    }

    // Update is called once per frame
    void Update()
    {
        walk();
    }

    void walk()
    {
        //rbPlayer.linearVelocity = move.ReadValue<Vector2>();//Vector de dos componentes que permite darle un vector de velocidad. El tipo de valor depende del mapa
        //Lo malo es que se afecta para todas las direcciones

        //Movimiento en el eje X del rigidbody del Player
        float linearXVelocity = move.ReadValue<Vector2>().x;
        rbPlayer.linearVelocity = new Vector2(linearXVelocity * speed, rbPlayer.linearVelocity.y);//Tomamos la velocidad en X y Y por separado
        //Se llama al mismo objeto para que respete la velocidad de caida y que no interfiera con los demás objetos
        //hay que tener cuidado con la velocidad máxima que se le da al jugador para que no atraviese objetos

    }
}
