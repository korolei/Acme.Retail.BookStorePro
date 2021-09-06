using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Acme.Retail.BookStorePro.Parties;
using Acme.Retail.BookStorePro.EntityFrameworkCore;
using Xunit;

namespace Acme.Retail.BookStorePro.Parties
{
    public class PartyRepositoryTests : BookStoreProEntityFrameworkCoreTestBase
    {
        private readonly IPartyRepository _partyRepository;

        public PartyRepositoryTests()
        {
            _partyRepository = GetRequiredService<IPartyRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _partyRepository.GetListAsync(
                    partyType: "9707dabfc54f40b8ab3c350d66b0baf72f4a527b539848a6b105c64ca74c13c26df79f3ae9f848fcb3f401135493da0519a5fbc57a5f4c239e1ebe23f33427b86ff5dfca379f449d9edeb62d3bd7c5bda66dab438dd34c76b1fe39533342f909e480c3f246e14f94b142e1eb8c425be6539d938f15e6485293db381f59",
                    status: "e1a36e72d18c4211ae0ac4080050051e495b91b4831e402f8e"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _partyRepository.GetCountAsync(
                    partyType: "9d550861f69f438d9fd277f941e2c679c27374a761d4483e8640acf8e613335703d03c01fb6043f0bb301ab95ea23e11528fea40c2eb41fc9fddc48e8721d49d0c8296bd275c43d3b754b99ec1d39f43a412071a3da74d708f095ad570d29b91159e82064d7b4fcca6ad639d19310bc6721d807fc5ff42dc9db4f88418",
                    status: "5153e67a86244a7d94108518835ee6554344589920a74cbb93"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}