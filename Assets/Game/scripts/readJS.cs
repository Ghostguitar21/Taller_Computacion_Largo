using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class readJS : MonoBehaviour
{
    public TextAsset GameData;
    [System.Serializable]

    public class coleccionables
    {
        public string nombre;
        public string rareza;
        public string valor;
    }
    [System.Serializable]

public class coleccionablesLista
    {
        public coleccionables[] coleccion;
    }

    public coleccionables losColeccionables = new coleccionables();
    void Start()
    {
        losColeccionables = JsonUtility.FromJson<coleccionables>(GameData.text);
    }

    
    void Update()
    {
        
    }
}
