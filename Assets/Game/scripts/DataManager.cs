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
    List<readJS.coleccionable> colecionables = new List<readJS.coleccionable>();

    void Start()
    {
        cargarJS();
        BuscarC("Moneda");
        botonBC();
    }


    void Update()
    {

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
}

