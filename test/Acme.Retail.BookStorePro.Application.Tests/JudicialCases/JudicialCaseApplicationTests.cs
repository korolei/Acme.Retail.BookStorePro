using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.Retail.BookStorePro.JudicialCases
{
    public class JudicialCasesAppServiceTests : BookStoreProApplicationTestBase
    {
        private readonly IJudicialCasesAppService _judicialCasesAppService;
        private readonly IRepository<JudicialCase, Guid> _judicialCaseRepository;

        public JudicialCasesAppServiceTests()
        {
            _judicialCasesAppService = GetRequiredService<IJudicialCasesAppService>();
            _judicialCaseRepository = GetRequiredService<IRepository<JudicialCase, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _judicialCasesAppService.GetListAsync(new GetJudicialCasesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.JudicialCase.Id == Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9")).ShouldBe(true);
            result.Items.Any(x => x.JudicialCase.Id == Guid.Parse("c67c1978-3712-428f-8a2f-b0ffe0834ca5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _judicialCasesAppService.GetAsync(Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new JudicialCaseCreateDto
            {
                CaseNumber = "6691d33e6d9144a9a531",
                CaseName = "0dedabeab0814a53952bff8fdd58df1bea08ad4a9c04401188d46278ba33125e0da87562ce4a4c1787dd747f9cf883a80609505bff5c4f89aa2d94defadb6510039896e5b0704c0ea0306812f26a7b9977e84ca612214187a31340d9f6ea7f9b9f3c370de77c4c92bd3a647a32e82888147fd938667b436397f39b3596",
                Status = "3d0d373be26b4b6fbd3ac1732de1a398eec88fac44e241a595655e3369fabbe59138bec4ffd644d19e3560b1b6314cb0a0b6788ce6484e66b1e93f54ddbc30a52750fc17108f4519b8ddfcc9721ccb72c1332284a03944e2bebd6b0b94c031a7ac92af0ef78d421ca51630eaada018432db8b25f7e1046908e7d065faa"
            };

            // Act
            var serviceResult = await _judicialCasesAppService.CreateAsync(input);

            // Assert
            var result = await _judicialCaseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CaseNumber.ShouldBe("6691d33e6d9144a9a531");
            result.CaseName.ShouldBe("0dedabeab0814a53952bff8fdd58df1bea08ad4a9c04401188d46278ba33125e0da87562ce4a4c1787dd747f9cf883a80609505bff5c4f89aa2d94defadb6510039896e5b0704c0ea0306812f26a7b9977e84ca612214187a31340d9f6ea7f9b9f3c370de77c4c92bd3a647a32e82888147fd938667b436397f39b3596");
            result.Status.ShouldBe("3d0d373be26b4b6fbd3ac1732de1a398eec88fac44e241a595655e3369fabbe59138bec4ffd644d19e3560b1b6314cb0a0b6788ce6484e66b1e93f54ddbc30a52750fc17108f4519b8ddfcc9721ccb72c1332284a03944e2bebd6b0b94c031a7ac92af0ef78d421ca51630eaada018432db8b25f7e1046908e7d065faa");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new JudicialCaseUpdateDto()
            {
                CaseNumber = "d9c6a5bbb79a4328ba4c",
                CaseName = "d5b9e8496bbc4be28ac8757adb0b5ba7515a9d2028b64979b28d420edea1cd07c35900b9e68048e5b825c6aa33ea6df97f5386dcf2da49a2a37036e4f06002300b7ee0fadc05491fb5ceb34af0750fb50b55434558d64770a71642729e0b95c226798414c26f491b847bd229fc5ac98c8cea4fac32844e0491cb6ace94",
                Status = "b135fa789cfb47e48b3a72de2de3bb71f77a8dddec074705bd3c70a2a42cfb72d858ef6d88034d58a31397ae95fa17f9a875a7053a49456b9360dbf2b8a580dcca5ddbd834014bda8adcf4aa929ee28bd00768ca7b7a4262b1a2d0088e19e24a6938dd9534184ec69e674cc161187dd97bfefc705ae24d28a9e311761e"
            };

            // Act
            var serviceResult = await _judicialCasesAppService.UpdateAsync(Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9"), input);

            // Assert
            var result = await _judicialCaseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CaseNumber.ShouldBe("d9c6a5bbb79a4328ba4c");
            result.CaseName.ShouldBe("d5b9e8496bbc4be28ac8757adb0b5ba7515a9d2028b64979b28d420edea1cd07c35900b9e68048e5b825c6aa33ea6df97f5386dcf2da49a2a37036e4f06002300b7ee0fadc05491fb5ceb34af0750fb50b55434558d64770a71642729e0b95c226798414c26f491b847bd229fc5ac98c8cea4fac32844e0491cb6ace94");
            result.Status.ShouldBe("b135fa789cfb47e48b3a72de2de3bb71f77a8dddec074705bd3c70a2a42cfb72d858ef6d88034d58a31397ae95fa17f9a875a7053a49456b9360dbf2b8a580dcca5ddbd834014bda8adcf4aa929ee28bd00768ca7b7a4262b1a2d0088e19e24a6938dd9534184ec69e674cc161187dd97bfefc705ae24d28a9e311761e");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _judicialCasesAppService.DeleteAsync(Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9"));

            // Assert
            var result = await _judicialCaseRepository.FindAsync(c => c.Id == Guid.Parse("3d7b76c4-b566-4627-b33c-8b9052c04fb9"));

            result.ShouldBeNull();
        }
    }
}