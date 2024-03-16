using MenuApi.Domains.Menus;
using MenuApi.Services.Menus;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuApiTests.Services
{

    
    public class BasicMenuServiceUnitTest
    {

        public class GetMenuTests
        {

            private readonly int _menuId = 1;

            [Fact]
            public void shouldCallFillMenuAndReturnMenu()
            {
                var _mockMenuService = new Mock<BasicMenuService>();

                _mockMenuService.CallBase = true;

                _mockMenuService.Protected()
                    .Setup("fillMenu", ItExpr.IsAny<Menu>());

                Menu menu = _mockMenuService.Object.getMenu(_menuId);

                Assert.NotNull(menu);
                Assert.Equal(_menuId, menu.Id);
                _mockMenuService.Protected().Verify("fillMenu", Times.Once(), ItExpr.IsAny<Menu>());
            }
        }

        public class FillMenuTests: BasicMenuService
        {

            private readonly int _menuId = 1;

            [Fact]
            public void shouldReturnFilledMenu()
            {
                Menu menu = new Menu()
                {
                    Id = 1
                };

                fillMenu(menu);

                Assert.Equal(2, menu.Items.Count);
                Assert.Equal("Spaghetti", menu.Items[0].Name);
                Assert.Equal("Lasagna", menu.Items[1].Name);
            }
        }


    }
}
