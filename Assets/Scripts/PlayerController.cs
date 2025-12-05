using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Rigidbody
    /*Se maneja un controlador diferente par ala parte de la interfaz y para el jugador*/
    public Rigidbody2D rbPlayer;//Permite tener físicas como colisiones o gravedad

    //Gestión de las inputs
    public InputActionAsset input;
    private InputActionMap inputMap;
    private InputAction move;
    private InputAction jump;

    //Parámetros de movimiento
    public float speed = 1.0f;
    public float jumpSpeed = 5.0f;

    //Lógica de los pies
    public FootLogic footLogic;

    //Componentes
    private Animator playerAnimator;
    private SpriteRenderer playerSprite;

    void Awake()//al tomar la función start podemos tener problemas por el orden de incialización, es mejor usar awake
    {
        //Input se llama antes que el start
        inputMap = input.FindActionMap("Player");//Se busca el mapa de acciones llamado "Player"
        move = inputMap.FindAction("Move");//Se busca la acción llamada "Move"
        jump = inputMap.FindAction("Jump");//Se busca la acción llamada "Jump"
    }

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        input.Enable();//Habilita el sistema de eventos para el salto
        jump.started += jumpFunction;
    }

    private void OnDisable()
    {
        input.Disable();
        jump.started -= jumpFunction;//El evento se deja de suscribir
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        if (!footLogic.isGrounded)
        {
            playerAnimator.SetBool("jump", false);
        }
    }

    void walk()
    {
        
        //rbPlayer.linearVelocity = move.ReadValue<Vector2>();//Vector de dos componentes que permite darle un vector de velocidad. El tipo de valor depende del mapa
        //Lo malo es que se afecta para todas las direcciones

        //Movimiento en el eje X del rigidbody del Player
        float linearXVelocity = move.ReadValue<Vector2>().x;
        if (linearXVelocity != 0) playerAnimator.SetBool("walk", true);
        else playerAnimator.SetBool("walk", false);
        if (linearXVelocity < 0) playerSprite.flipX = true;//Este y el de abajo son lo que permite que se voltee el personaje
        if (linearXVelocity > 0) playerSprite.flipX = false;
        rbPlayer.linearVelocity = new Vector2(linearXVelocity * speed, rbPlayer.linearVelocity.y);//Tomamos la velocidad en X y Y por separado
        //Se llama al mismo objeto para que respete la velocidad de caida y que no interfiera con los demás objetos
        //hay que tener cuidado con la velocidad máxima que se le da al jugador para que no atraviese objetos

    }

    void jumpFunction(InputAction.CallbackContext context)
    {
        if (footLogic.isGrounded)
        {
            playerAnimator.SetBool("jump", true);
            //Se va a dar una velocidad de caida al cuerpo. Se llama al rigidbody para que funcione
            //Se agrega una fuerza de tipo impulso que no se mantiene constante
            rbPlayer.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);//La componente en x es cero, podemos poner más parámetros para el tipo de movimiento
        }
        
    }
}
