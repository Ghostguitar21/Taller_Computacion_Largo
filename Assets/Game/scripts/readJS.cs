using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

public class coleccionablesLista
    {
        public coleccionable[] coleccionables;
    }

    public coleccionable losColeccionables = new coleccionable();
    void Start()
    {
        losColeccionables = JsonUtility.FromJson<coleccionable>(GameData.text);
    }

    
    void Update()
    {
        
    }
    [System.Serializable]
    public class misionesLista
    {
        public misiones[] misiones;
    }
}
