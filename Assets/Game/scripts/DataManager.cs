using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static readJS;

public class DataManager : MonoBehaviour

{

    public TextMeshProUGUI datosJS;
    public coleccionablesLista datos;
    public TMP_InputField busquedaC;
    public TextAsset GameData;
    public TextMeshProUGUI misionActualTexto;
    public TextAsset MisionesData;

    //---------------------------------------
    [Header("UI Botones Mision Manto")]
    public GameObject botonUsarManto;
    public GameObject botonNoUsarManto;

    [Header("Paneles de Resultado Mision Manto")]
    public GameObject panelMisionMantoPasada;
    public GameObject panelMisionMantoFallida;
    // -------------------------------------


    [Header("Paneles de Resultado Mision Suerte")]

    public GameObject botonOpcion1;
    public GameObject botonOpcion2;
    public GameObject botonOpcion3;
    public GameObject botonOpcion4;

    public GameObject panelMisionSuertePasada;
    public GameObject panelMisionSuerteFallida;
    // -------------------------------------

    [Header("Acertijo")]

    public GameObject Verdadero;
    public GameObject Falso;
    public GameObject panelAcertijoPasado;
    public GameObject panelAcertijoFallar;


    [Header("Paneles validar volver")]
    public GameObject panelValidarRegresar;

    [Header("Scroll View")]
    public Transform contenedorLista;
    public GameObject itemPrefab;

    [Header("Paneles Detalle")]
    public GameObject panelDetalle;
    public TextMeshProUGUI textoDetalleColeccionable;

    List<misiones> listaMisiones = new List<misiones>();
    Stack<misiones> pilaMisiones = new Stack<misiones>();
    List<readJS.coleccionable> colecionables = new List<readJS.coleccionable>();
    Stack<misiones> historialUndo = new Stack<misiones>();

    void Start()
    {
        OcultarBotonesManto();
        OcultarPanelResultadoManto();
        OcultarPanelesAcertijo();
        OcultarBotonesSuerte();
        OcultarPanelResultadoSuerte();
        OcultarPanelValidarRegresar();
        OcultarAcertijo();
        panelDetalle.SetActive(false);

        
        cargarJS();
        BuscarC("Moneda");
        botonBC();
        CargarMisiones(); 
    }


    void Update()
    {

    }
    public void ValidarRegresar()
    {

        panelValidarRegresar.SetActive(true);

    }
    public void OcultarPanelValidarRegresar()
    {

        panelValidarRegresar.SetActive(false);

    }

    private void OcultarBotonesManto()
    {
        if (botonUsarManto != null) botonUsarManto.SetActive(false);
        if (botonNoUsarManto != null) botonNoUsarManto.SetActive(false);
    }

    private void OcultarBotonesSuerte()
    {
        if (botonOpcion1 != null) botonOpcion1.SetActive(false);
        if (botonOpcion2 != null) botonOpcion2.SetActive(false);
        if (botonOpcion3 != null) botonOpcion3.SetActive(false);
        if (botonOpcion4 != null) botonOpcion4.SetActive(false);

    }


    private void OcultarAcertijo()
    {
        if (Verdadero != null) Verdadero.SetActive(false);
        if (Falso != null) Falso.SetActive(false);
    }

    public void PasarNivelManto()
    {

        panelMisionMantoPasada.SetActive(true);

    }
    public void PasarNivelSuerte()
    {

        panelMisionSuertePasada.SetActive(true);

    }
    public void FallarNivelManto()
    {

        panelMisionMantoFallida.SetActive(true);

    }
    public void FallarNivelSuerte()
    {

        panelMisionSuerteFallida.SetActive(true);

    }

    public void OcultarPanelesAcertijo()
    {
        panelAcertijoPasado.SetActive(false);
        panelAcertijoFallar.SetActive(false);
    }

    public void PasarAcertijo()
    {
        panelAcertijoPasado.SetActive(true);
    }


    public void FallarAcertijo()
    {
        panelAcertijoFallar.SetActive(true);
    }
    public void OcultarPanelResultadoManto()
    {
        panelMisionMantoPasada.SetActive(false);
        panelMisionMantoFallida.SetActive(false);   

    }

    public void OcultarPanelResultadoSuerte()
    {
        panelMisionSuertePasada.SetActive(false);
        panelMisionSuerteFallida.SetActive(false);

    }

    public void cargarJS()

    {
        if (GameData != null)
        {
            colecionables.Clear();
        
            datos = JsonUtility.FromJson<coleccionablesLista>(GameData.text);
            foreach (coleccionable c in datos.coleccionables)
            {
                colecionables.Add(c);
            }
            Debug.Log("# objetos caragos" + datos.coleccionables.Length);
            datosJS.text = "Objeto:" + datos.coleccionables[0].nombre + "\nRareza:" + datos.coleccionables[0].rareza + "\nValor:" + datos.coleccionables[0].valor;
            CrearListaColeccionables();

        }


    }

    public readJS.coleccionable BuscarC(string nombreB)
    {
        if (colecionables == null || colecionables.Count == 0)
        {
            Debug.Log("No existe colecion");
            return null;

        }

        foreach (readJS.coleccionable a in datos.coleccionables)
        {
            if (a.nombre == nombreB)
            {
                datosJS.text = "Objeto: " + a.nombre + "\nvalor: " + a.valor + "\nRareza: " + a.rareza;
                Debug.Log("Objeto: " + a.nombre + "\nValor: " + a.valor + " \nRareza: " + a.rareza);
                return a;

            }
            else {

                Debug.Log("Objeto no encontrado");
            }

        }
        Debug.Log("El objeto '" + nombreB + "' no existe en el JSON.");
        return null;

    }

    public void botonBC()
    {
        string textoUsuario = busquedaC.text;
        BuscarC(textoUsuario);
   
    }

    public void CargarMisiones()
    {
        if (MisionesData == null) return;

        readJS.lasMisiones datosM =
            JsonUtility.FromJson<readJS.lasMisiones>(GameData.text);

        listaMisiones.Clear();
        pilaMisiones.Clear();

        foreach (misiones m in datosM.misiones)
        {
            listaMisiones.Add(m);
            pilaMisiones.Push(m); 
        }

        MostrarMisionActual();
    }

    public void MostrarMisionActual()
    {
        if (pilaMisiones.Count > 0)
        {
            misiones actual = pilaMisiones.Peek();
            misionActualTexto.text =
                "Misión Actual:\n" +
                actual.Titulo + "\n\n" +
                actual.Descripcion;
            
            if (actual.Titulo == "El velo del silencio")
            {
                botonUsarManto.SetActive(true);
                botonNoUsarManto.SetActive(true);
            }
            else
            {
                OcultarBotonesManto();//////////
            }
            if (actual.Titulo == "El juicio del azar")
            {
                botonOpcion1.SetActive(true);
                botonOpcion2.SetActive(true);
                botonOpcion3.SetActive(true);
                botonOpcion4.SetActive(true);

            }
            else
            {
                OcultarBotonesSuerte();
                OcultarPanelResultadoSuerte();
            }

            if (actual.Titulo == "Bifurcación en el camino")
            {
                Verdadero.SetActive(true);
                Falso.SetActive(true);
            }
            else
            {
                OcultarAcertijo();//////////
            }
        }

        else
        {
            misionActualTexto.text = "No hay misiones activas.";
            OcultarBotonesManto();////////
            OcultarBotonesSuerte() ;
            OcultarAcertijo();
        }
    }

    public void CompletarMision()
    {
        if (pilaMisiones.Count > 0)
        {
            misiones m = pilaMisiones.Pop();
            historialUndo.Push(m);
            MostrarMisionActual();
        }
    }

    public void Deshacer()
    {
        if (historialUndo.Count > 0)
        {
            misiones m = historialUndo.Pop();
            pilaMisiones.Push(m);
            MostrarMisionActual();
        }
        else
        {
            ValidarRegresar();
        }
    }

    void CrearListaColeccionables()
    {
        foreach (Transform hijo in contenedorLista)
        {
            Destroy(hijo.gameObject);
        }

        foreach (var c in datos.coleccionables)
        {
            GameObject nuevoItem = Instantiate(itemPrefab, contenedorLista);

            TextMeshProUGUI texto = nuevoItem.GetComponentInChildren<TextMeshProUGUI>();
            texto.text = c.nombre;

            Button boton = nuevoItem.GetComponent<Button>();
            boton.onClick.AddListener(() =>
            {
                MostrarDetalle(c);
            });
        }
    }

    void MostrarDetalle(readJS.coleccionable c)
    {
        textoDetalleColeccionable.text =
            "Objeto: " + c.nombre +
            "\nRareza: " + c.rareza +
            "\nValor: " + c.valor;

        panelDetalle.SetActive(true);

        StopAllCoroutines(); 
        StartCoroutine(OcultarPanelDespuesDeTiempo(3f));
    }

    IEnumerator OcultarPanelDespuesDeTiempo(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        panelDetalle.SetActive(false);
    }
}

