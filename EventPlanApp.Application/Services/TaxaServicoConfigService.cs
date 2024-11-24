using EventPlanApp.Domain.Entities;
using EventPlanApp.Domain.Interfaces;

public class TaxaServicoConfigService
{
    private readonly IUnitOfWork _unitOfWork;

    public TaxaServicoConfigService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task SalvarTaxaServicoConfig(int eventoId, decimal? taxaFixa, decimal? taxaPercentual)
    {
        // Aqui você está tentando pegar as taxas existentes para o evento
        var taxasExistentes = await _unitOfWork.TaxaServicoConfigRepository.GetByEventoIdAsync(eventoId);

        if (taxasExistentes.Any())
        {
            // Se existir, pega a primeira taxa e atualiza
            var taxaExistente = taxasExistentes.First(); // Ou FirstOrDefault(), dependendo do seu caso
            taxaExistente.TaxaFixa = taxaFixa;
            taxaExistente.TaxaPercentual = taxaPercentual;

            _unitOfWork.TaxaServicoConfigRepository.Update(taxaExistente);
        }
        else
        {
            // Corrigindo a criação da nova taxa, passando os parâmetros necessários para o construtor
            var novaTaxa = new TaxaServicoConfig(eventoId, taxaFixa, taxaPercentual);

            await _unitOfWork.TaxaServicoConfigRepository.AddAsync(novaTaxa);
        }

        // Commit da transação
        await _unitOfWork.CommitAsync();
    }
}
