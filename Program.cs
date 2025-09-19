using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria os modelos de hóspedes e cadastra na lista de hóspedes
List<Pessoa> hospedes = new List<Pessoa>()
{
    new Pessoa(nome: "Hóspede 1"),
    new Pessoa(nome: "Hóspede 2")
};

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
try
{
    Reserva reserva = new Reserva(diasReservados: 5);
    reserva.CadastrarSuite(suite);
    reserva.CadastrarHospedes(hospedes);

    Console.WriteLine($"Suíte: {reserva.Suite}");
    Console.WriteLine($"Dias Reservados: {reserva.DiasReservados}");
    Console.WriteLine($"Quantidade de Hóspedes: {reserva.ObterQuantidadeHospedes()}");
    Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");

} catch (Exception ex) when (ex is ArgumentException || ex is InvalidOperationException)
{
    Console.WriteLine($"Erro ao fazer a reserva: {ex.Message}");
    return;
}