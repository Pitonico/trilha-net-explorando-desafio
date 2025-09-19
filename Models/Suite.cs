using System.Text.Json;
using System.Globalization;

namespace DesafioProjetoHospedagem.Models;

public class Suite
{
    public Suite() { }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }

    public string TipoSuite { get; set; }
    public int Capacidade { get; set; }
    public decimal ValorDiaria { get; set; }

    public override string ToString()
    {
        var options = new JsonSerializerOptions() { WriteIndented = false };

        return JsonSerializer.Serialize( new
        {
            Tipo = TipoSuite,
            Capacidade = Capacidade,
            ValorDiaria = ValorDiaria.ToString("C", new CultureInfo("pt-BR"))
        }, options);
    }

}
