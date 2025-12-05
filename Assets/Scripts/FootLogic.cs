using UnityEngine;

public class FootLogic : MonoBehaviour
{
    public bool isGrounded = false;
    //Cuando entra es true y cuando sale es false
    //Toma en cuenta cómo se está interactuando con los objetos con tag terreno

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("terrain"))
        {
            isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("terrain"))
        {
            isGrounded = false;
        }
    }
}
