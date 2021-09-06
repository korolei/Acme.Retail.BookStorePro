using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Acme.Retail.BookStorePro.JudicialCases;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCasesDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IJudicialCaseRepository _judicialCaseRepository;

        public JudicialCasesDataSeedContributor(IJudicialCaseRepository judicialCaseRepository)
        {
            _judicialCaseRepository = judicialCaseRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _judicialCaseRepository.InsertAsync(new JudicialCase
            (
                id: Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9"),
                caseNumber: "d4eef2bbeb154698bcf2",
                caseName: "751e34f8e15b4df9b66eab731ba5de405b189cee9e8c421eb87967f0dc080d93f21c9aaad19e4f9ab49a1952c6ef1aaf14bcc2c64645421d81f51eafe4041f185ef1b77629e045c5b419b57b8bb9d6e02cc6a3cf5de84f069dbd6d4653e02834af4ec4953c474ee6a1edecebee6f2447de8db7ab6afb4dbe910654853e",
                status: "5391a1ba7cb74224af511f8d5894746ce91bbfb9ba4d48bfa29b4ab748bba85d0510ffc79aa344b8aca009302c032b5182371764d04a45a498baf06f1b70ff271c31343d94ff4cf8b987a78e5bd8eb1d96c4f0edd002400ea17f67c8504b0184cc34f43480b5445b81cf25a3c0403e4cc1d6c3bd5260480f9b4ec6ff7f"
            ));

            await _judicialCaseRepository.InsertAsync(new JudicialCase
            (
                id: Guid.Parse("c67c1978-3712-428f-8a2f-b0ffe0834ca5"),
                caseNumber: "aa50289729ac48c68d63",
                caseName: "6c1db4c221f64d0d9b4880cd3a769ad3289d30d5adee44709681decd1958d98340130987d3384364bd33ff734ed24174172118e4233f4f55b7cabeeb7962e8a717fde82c6873438395b6c11d79cb8e1f5d36a97949a343d88a063126a7b779e9edaf5c557b0e492e80f7253c59fe101c96608eb25c6f4c21801cfb2a96",
                status: "d9732978d02f45a6a541b49b5ddc7b0dba7eaa13d2f14714824dfef46f7edaddc3a34b1f23a64d21a1f08fff718432e59ddfe2646fb74886aefd737b0b49670481d90be1cb5a498994d5596ab085556307ef0e68b98a481a9a1cb3758697021e6d3a2d6ed53f41e4bf9c96143438cefeb8bad9453e144f429e5b933fdc"
            ));
        }
    }
}