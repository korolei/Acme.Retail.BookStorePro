using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.Retail.BookStorePro.Parties
{
    public class PartiesAppServiceTests : BookStoreProApplicationTestBase
    {
        private readonly IPartiesAppService _partiesAppService;
        private readonly IRepository<Party, Guid> _partyRepository;

        public PartiesAppServiceTests()
        {
            _partiesAppService = GetRequiredService<IPartiesAppService>();
            _partyRepository = GetRequiredService<IRepository<Party, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _partiesAppService.GetListAsync(new GetPartiesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("803f2715-6032-42dd-94e4-b0e2e22bc896")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _partiesAppService.GetAsync(Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new PartyCreateDto
            {
                PartyType = "3320084023dd4aa8b91b7fc50aa841f1a0aa8ed07b494d00a140b18551297cf7fc73ee4e75e6495d8326fbf7fd2b1c69c2be0654b9cc41bea5cbec23d44266f997f2d9fb67e1464c9b90956980fc58e37173bf5fafdf4eb4af6adb4d47e5e729aac36e278b274ec9951d711c8f5eb203d3a00f7d91e141f0868dd3353c",
                Status = "c5bfeb9aefad481190f878376caa075f0eca6d5a980b4ff4bd"
            };

            // Act
            var serviceResult = await _partiesAppService.CreateAsync(input);

            // Assert
            var result = await _partyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.PartyType.ShouldBe("3320084023dd4aa8b91b7fc50aa841f1a0aa8ed07b494d00a140b18551297cf7fc73ee4e75e6495d8326fbf7fd2b1c69c2be0654b9cc41bea5cbec23d44266f997f2d9fb67e1464c9b90956980fc58e37173bf5fafdf4eb4af6adb4d47e5e729aac36e278b274ec9951d711c8f5eb203d3a00f7d91e141f0868dd3353c");
            result.Status.ShouldBe("c5bfeb9aefad481190f878376caa075f0eca6d5a980b4ff4bd");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new PartyUpdateDto()
            {
                PartyType = "1cc3a790e9f740e583c4f217d4f590a84ee3ca26e8e749179af64beb0201d2ab021aea64a51441108b1fd21fd931d29f6004834d21da42b985876ac35ef864f9a948b49cf4a546f6b1bd85ee8565613bf3035d9a095248ac9deb6cc8f87dedda6db9b84f7673404f9376dbd244d6e20bf50e365a8c254fae825901e79b",
                Status = "db1ad23d60c442e0a99ba5c4db89143e468b2fe43a3f4c80bd"
            };

            // Act
            var serviceResult = await _partiesAppService.UpdateAsync(Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f"), input);

            // Assert
            var result = await _partyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.PartyType.ShouldBe("1cc3a790e9f740e583c4f217d4f590a84ee3ca26e8e749179af64beb0201d2ab021aea64a51441108b1fd21fd931d29f6004834d21da42b985876ac35ef864f9a948b49cf4a546f6b1bd85ee8565613bf3035d9a095248ac9deb6cc8f87dedda6db9b84f7673404f9376dbd244d6e20bf50e365a8c254fae825901e79b");
            result.Status.ShouldBe("db1ad23d60c442e0a99ba5c4db89143e468b2fe43a3f4c80bd");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _partiesAppService.DeleteAsync(Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f"));

            // Assert
            var result = await _partyRepository.FindAsync(c => c.Id == Guid.Parse("6932f696-21bb-48d9-accb-31d407e05b4f"));

            result.ShouldBeNull();
        }
    }
}