using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static readJS;

public class readJS : MonoBehaviour
{
    public TextAsset GameData;
    
    
    [System.Serializable]
    public class coleccionable
    {
        public string nombre;
        public string rareza;
        public string valor;
    }
    [System.Serializable]
    public class mision
    {
     public int id;
     public string titulo;
     public string descripcion;
    }
    [System.Serializable]

    public class DataMaestra
    {
        public coleccionable[] coleccionables;
        public misiones[] misiones;
    }

    public DataMaestra misDatosCargados;

    public class coleccionablesLista
    {
        public coleccionable[] coleccionables;
    }

    public class lasMisiones
    {
        public  misiones[] misiones;
    }

    public coleccionable losColeccionables = new coleccionable();
    public misiones misiones = new misiones(); 
    void Start()
    {
        if (GameData != null)
        {
            
            misDatosCargados = JsonUtility.FromJson<DataMaestra>(GameData.text);

            
           
        }
        else
        {
            Debug.LogError("¡No has asignado el archivo JSON en el Inspector!");
        }
    }
}