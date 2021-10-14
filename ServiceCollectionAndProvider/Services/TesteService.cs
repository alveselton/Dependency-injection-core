

namespace ServiceCollectionAndProvider.Services
{
    public class TesteService : ITesteService
    {
        private readonly IDemoService _demoService;
        public TesteService(IDemoService demoService)
        {
            _demoService = demoService;
        }
        public void ServicoTeste()
        {
            for (int i = 0; i < 10; i++)
            {
                _demoService.ServicoDemo(i);
            }
        }
    }
}
