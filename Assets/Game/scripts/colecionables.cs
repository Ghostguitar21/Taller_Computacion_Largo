using UnityEngine;


[System.Serializable]
public class colecionables
{
    [SerializeField] private string nombre;
    [SerializeField] private string rareza;
    [SerializeField] private string valor;

    public colecionables()
    {
    }

    public colecionables(string nombre, string rareza, string valor)
    {
        this.nombre = nombre;
        this.rareza = rareza;
        this.valor = valor;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Rareza { get => rareza; set => rareza = value; }
    public string Valor { get => valor; set => valor = value; }
}

