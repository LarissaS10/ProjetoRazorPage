namespace Projeto_AT_DotNet.Services
{
    //Atv 1
    public delegate decimal CalcularDescontoDelegate(decimal precoOriginal);

    public static class ServicoDeDesconto
    {
        public static decimal AplicarDescontoPacoteTuristico(decimal precoOriginal)
        {
            const decimal taxaDeDesconto = 0.10M;

            decimal precoFinal = precoOriginal - (precoOriginal * taxaDeDesconto);

            return Math.Max(0, precoFinal);
        }
    }
}
