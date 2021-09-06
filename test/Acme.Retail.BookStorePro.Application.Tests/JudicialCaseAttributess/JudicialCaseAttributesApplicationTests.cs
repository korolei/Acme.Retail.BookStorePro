using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.Retail.BookStorePro.JudicialCaseAttributess
{
    public class JudicialCaseAttributessAppServiceTests : BookStoreProApplicationTestBase
    {
        private readonly IJudicialCaseAttributessAppService _judicialCaseAttributessAppService;
        private readonly IRepository<JudicialCaseAttributes, Guid> _judicialCaseAttributesRepository;

        public JudicialCaseAttributessAppServiceTests()
        {
            _judicialCaseAttributessAppService = GetRequiredService<IJudicialCaseAttributessAppService>();
            _judicialCaseAttributesRepository = GetRequiredService<IRepository<JudicialCaseAttributes, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _judicialCaseAttributessAppService.GetListAsync(new GetJudicialCaseAttributessInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("da7db53e-9368-4093-bee7-9cc571a55e54")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _judicialCaseAttributessAppService.GetAsync(Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new JudicialCaseAttributesCreateDto
            {
                Key = "c3ae34e601c5437d9938e5b76cf044aa150d1af39c7c4b208655876928312c53dd7c88e7ffd14881bc99fb1cb801f8800501c72809bd45c28a6f75ca42eb3e1ba31e0aa09a35404cb6d3f39588eb761ab001fdcde46e46efaf8dbbba4c79700d2169af8786d94a7195d706970e50a98be7668316fb964e069364028283",
                Value = "d2d537b70da7478d999a822c8f185aa6415270ee483e40c198786c39233b3c831468be3d2bed4b8b8881639917843f55243c22a0814b46f9b88e199b7f1e4609f6aa3fa691dc44ae80629112f780bcba6bc71d7624d3431c9812886ebbbba66e42516ae68521439faa972361ff60a2bed003ba64cb174a85a293cd873a"
            };

            // Act
            var serviceResult = await _judicialCaseAttributessAppService.CreateAsync(input);

            // Assert
            var result = await _judicialCaseAttributesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key.ShouldBe("c3ae34e601c5437d9938e5b76cf044aa150d1af39c7c4b208655876928312c53dd7c88e7ffd14881bc99fb1cb801f8800501c72809bd45c28a6f75ca42eb3e1ba31e0aa09a35404cb6d3f39588eb761ab001fdcde46e46efaf8dbbba4c79700d2169af8786d94a7195d706970e50a98be7668316fb964e069364028283");
            result.Value.ShouldBe("d2d537b70da7478d999a822c8f185aa6415270ee483e40c198786c39233b3c831468be3d2bed4b8b8881639917843f55243c22a0814b46f9b88e199b7f1e4609f6aa3fa691dc44ae80629112f780bcba6bc71d7624d3431c9812886ebbbba66e42516ae68521439faa972361ff60a2bed003ba64cb174a85a293cd873a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new JudicialCaseAttributesUpdateDto()
            {
                Key = "3cb9befa54fd4b8fbd99cf37a245c9391ef0864f951f4cc583912233c068cb8e17ec3eff714944d89f248a7d03032d9f0df876d73abf47e2848f7c2b68bd1ad502f7443ca4c14919b3f19360ec4379a2b68f98fe0e70410499df779543497161d2b7080fc718446ca0c2715cb5fafb457ed8faac1977426fa94d324a79",
                Value = "845c8604f6fa48ddaa1c3ee66ea903fa0b2ac117e96447b785399974a3084fcb74a2c614878a4c02a5d13a0174dc4b310431814abbb3486ebc5b6a334cd11a35104a7b4e9cbe4fbdad3c703b2e846477a33e8e104f1b4583a0810658dfaecc65f6baa9352ee349f39ff491eaf5d807dc939cfaddd31345f1825d29abe2"
            };

            // Act
            var serviceResult = await _judicialCaseAttributessAppService.UpdateAsync(Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea"), input);

            // Assert
            var result = await _judicialCaseAttributesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key.ShouldBe("3cb9befa54fd4b8fbd99cf37a245c9391ef0864f951f4cc583912233c068cb8e17ec3eff714944d89f248a7d03032d9f0df876d73abf47e2848f7c2b68bd1ad502f7443ca4c14919b3f19360ec4379a2b68f98fe0e70410499df779543497161d2b7080fc718446ca0c2715cb5fafb457ed8faac1977426fa94d324a79");
            result.Value.ShouldBe("845c8604f6fa48ddaa1c3ee66ea903fa0b2ac117e96447b785399974a3084fcb74a2c614878a4c02a5d13a0174dc4b310431814abbb3486ebc5b6a334cd11a35104a7b4e9cbe4fbdad3c703b2e846477a33e8e104f1b4583a0810658dfaecc65f6baa9352ee349f39ff491eaf5d807dc939cfaddd31345f1825d29abe2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _judicialCaseAttributessAppService.DeleteAsync(Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea"));

            // Assert
            var result = await _judicialCaseAttributesRepository.FindAsync(c => c.Id == Guid.Parse("c3065537-b382-4b38-a4c9-337013b0ebea"));

            result.ShouldBeNull();
        }
    }
}