using UnityEngine;
[System.Serializable]
public class misiones 
{
    [SerializeField] private int id;
    [SerializeField] private string titulo;
    [SerializeField] private string descripcion;

    public misiones()
    { 
    }

    public misiones(int id, string titulo, string descripcion)
    {
        this.id = id;
        this.titulo = titulo;
        this.descripcion = descripcion;
    }

    public int Id { get => id; set => id = value; }
    public string Titulo { get => titulo; set => titulo = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
}
