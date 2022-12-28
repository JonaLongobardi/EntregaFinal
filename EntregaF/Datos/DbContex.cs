using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Datos
{
    public class DbContex
    {
        public DbContex(string valor) => Valor = valor;
        
        public string Valor { get; } 
        
    }
}
