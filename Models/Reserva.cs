using System.Globalization;
using System.Numerics;

namespace DesafioProjetoHospedagem.Models;

public class Reserva
{
    public List<Pessoa> Hospedes { get; private set; } = new();
    public Suite Suite { get; private set; }
    public int DiasReservados { get; private set; }

    public Reserva() { }

    public Reserva(int diasReservados)
    {
        if (diasReservados <= 0) throw new ArgumentException("Dias reservados deve ser maior que zero.");

        DiasReservados = diasReservados;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        Suite = Suite ?? throw new InvalidOperationException("A suíte deve ser cadastrada antes de cadastrar hóspedes.");

        if(!hospedes.Any()) throw new ArgumentException("A lista de hóspedes não pode estar vazia.");

        if(hospedes.Count > Suite.Capacidade) throw new ArgumentException("Número de hóspedes excede a capacidade da suíte.");

        Hospedes = hospedes;   
    }

    public void CadastrarSuite(Suite suite)
    {
        Suite = suite;
    }

    public int ObterQuantidadeHospedes()
    {
        return Hospedes.Count;
    }

    public string CalcularValorDiaria()
    {
        decimal valorPadrão = DiasReservados * Suite.ValorDiaria;

        decimal total = DiasReservados >= 10 ? valorPadrão * 0.9M : valorPadrão;

        return total.ToString("C", new CultureInfo("pt-BR"));
    }
}
