using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Acme.Retail.BookStorePro.JudicialCaseAttributess;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class JudicialCaseAttributessDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IJudicialCaseAttributesRepository _judicialCaseAttributesRepository;

        public JudicialCaseAttributessDataSeedContributor(IJudicialCaseAttributesRepository judicialCaseAttributesRepository)
        {
            _judicialCaseAttributesRepository = judicialCaseAttributesRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            await _judicialCaseAttributesRepository.InsertAsync(new JudicialCaseAttributes
            (
                id: Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea"),
                key: "a4272809aba74a73b8465c42a2ae034a1db44d5cc37a42c1a268d35ce41207450e7c7c2782b24606b11a3a4dff5385b956870fefb7b6414980cc06497152928c6f4474eb87a74febbb1fbf6b1da1c39d9bb63d5fc91a47b088578dee8f73c11b21e30c8a12e74fdd876b77e2c9b738380e024b8d4fba4029b7ad443ea1",
                value: "7da1a1175bd94c21b9abebad00d55ca0839dccc393514d4f9d7bacc1a10ad0694a32d939fdb14ca2ac64568601da177673c79b8464204ac5b6a323efc00f6186819c9249adbb4918a7387f36ee873f3ae1cdd84166cf4499ae5a394202c843aff922ef52febf4e9e82a2c4187d9603a14bba2fd952cb4e9b9f4767c64d"
            ));

            await _judicialCaseAttributesRepository.InsertAsync(new JudicialCaseAttributes
            (
                id: Guid.Parse("da7db53e-9368-4093-bee7-9cc571a55e54"),
                key: "8dd0d7974deb48c8aad974e84dbedc5bac1f54ec077b4f27b50467c36d8dd4be54b8a6112ab24b489a6bcb06e851b76c90c354c82eb14b158e35d26970f75b99ac98abbe91364af7867d5f57f37bfff9988d8ee70d9540198da059d8d09bfce183fee8831b614342ac707074416cbae93a85fa9242c741aea5504dd9d3",
                value: "243dda93104a4c0b9c060dad2fc01ea5e2cddadc5447474285c94d863bdec89f4e843b26694c4396a65b85634fceff7d1cbdf5439dcc4dc09d7ed9a052d8ab801bd0617f8a704545b386ed58d678e92c320fbe6e5a2140bc82e023c940469a51f28585b276ba4af3ba43a3c19a0777a4c358bf3875fa441d98e454c3b8"
            ));
        }
    }
}