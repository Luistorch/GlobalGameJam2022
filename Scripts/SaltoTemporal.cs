using UnityEngine;
using UnityEngine.SceneManagement;

public class SaltoTemporal : MonoBehaviour
{

    public InputManager input;
    public GameObject jugador;
    public GameObject camara;
    public int pasadoInd;
    Scene pasadoScene;
    public int presenteInd;
    Scene presenteScene;
    public bool presenteActivo = true;

    void Start() {
        pasadoScene = SceneManager.GetSceneByBuildIndex(pasadoInd);
        presenteScene = SceneManager.GetSceneByBuildIndex(presenteInd);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(input.timeTravel))
        {
            cambio();
        }
    }

    private void cambio()
    {
        // Pasado_Test
        // Presente_Test
        if (!presenteActivo)
        {
            // Pillamos la escena activa
            desactivarObjetos(pasadoScene);

            // Pillamos la otra escena
            activarObjetos(presenteScene);

            // Cambiamos de escena
            SceneManager.SetActiveScene(presenteScene);
            presenteActivo = !presenteActivo;
        }
        else if(presenteActivo)
        {
            // Pillamos la escena activa
            desactivarObjetos(presenteScene);

            // Pillamos la otra escena
            activarObjetos(pasadoScene);
            
            // Cambiamos de escena
            SceneManager.SetActiveScene(pasadoScene);
            presenteActivo = !presenteActivo;
        }
    }

    public void desactivarObjetos(Scene tiempo)
    {
        // Recoge los objetos
        tiempo.GetRootGameObjects();

        GameObject[] ObjetoAOcultar = tiempo.GetRootGameObjects();

        // Los esconde
        foreach (GameObject objet in ObjetoAOcultar)
        {
            objet.SetActive(false);
        }
    }
    public void activarObjetos(Scene tiempo)
    {
        // Recoge los objetos
        tiempo.GetRootGameObjects();

        GameObject[] ObjetoAMostrar = tiempo.GetRootGameObjects();

        // Los muestra
        foreach (GameObject objet in ObjetoAMostrar)
        {
            objet.SetActive(true);
        }
    }
}
