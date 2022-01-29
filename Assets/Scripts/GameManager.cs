using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject inventario = null;
    public GameObject personaje;

    public void recogerObjeto(ObjetoInteraccion _objetoInteraccion)
    {
        // Si tiene el inventario vacio
        if(inventario == null)
        {
            inventario = _objetoInteraccion.gameObject;
            inventario.transform.position = new Vector2(999,999);
            
            _objetoInteraccion.Mostrar(false);
            //objeto.GetComponent<ObjetoInteraccion>().enabled = false;
        }
        // Si ya tiene algo en el inventario
        else
        {
            Debug.Log("Tienes el inventario lleno");
            soltarObjeto();

            inventario = _objetoInteraccion.gameObject;
            inventario.transform.position = new Vector2(999,999);

            _objetoInteraccion.Mostrar(false);
            //objeto.GetComponent<ObjetoInteraccion>().enabled = false;
        }
    }

    public void soltarObjeto()
    {
        if (inventario != null)
        {
            Debug.Log(inventario.name + " soltado!");
            inventario.transform.position = personaje.transform.position;
            inventario.GetComponent<ObjetoInteraccion>().Mostrar(true);
            //objeto.GetComponent<ObjetoInteraccion>().enabled = true;
        
            inventario = null;
        }
    }

    public void usarObjeto(ObjetoInteraccion _objetoInteraccion, ObjetoSO so)
    {
        if (so.activable)
        {
            if(so.objetoNecesario.Equals(inventario.gameObject.name))
            {
                Debug.Log("Activado");
            }
            else
            {
                Debug.Log("No tienes el objeto necesario");
            }
            
        }
        else 
        {
            Debug.Log("Activado");
        }
    }
}