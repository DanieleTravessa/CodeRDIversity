using Xunit;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using GeladeiraSOLID.Models;
using GeladeiraSOLID.Tests.Services;
using GeladeiraSOLID.Tests.Mocks;
using GeladeiraSOLID.Services;
using GeladeiraSOLID.Repositories;

namespace GeladeiraSOLID.Tests.Services
{
    public class ItemServiceTests
    {
        private readonly ItemService _itemService;
        private readonly Mock<IItemRepository> _mockRepo;

        public ItemServiceTests()
        {
            // Obter o repositório mockado
            _mockRepo = MockItemRepository.GetMockItemRepository();
            _itemService = new ItemService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetItemById_ShouldReturnItem()
        {
            // Act
            var result = await _itemService.GetItemByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Tomate", result.Nome);
        }

        [Fact]
        public async Task GetAllItems_ShouldReturnListOfItems()
        {
            // Act
            var result = await _itemService.GetAllItemsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count() == 2);
            Assert.Contains(result, item => item.Nome == "Tomate");
        }

        [Fact]
        public async Task GetExpiredItems_ShouldReturnItems_WhenTheyAreExpired()
        {
            // Arrange
            var mockItems = new List<Item>
            {
                new Item { Nome = "Item Expirado", Categoria = "Categoria1", Prateleira = 1, Container = 1, Posicao = 1, Validade = DateTime.UtcNow.AddDays(-1) }, // Expirado
                new Item { Nome = "Item Válido", Categoria = "Categoria2", Prateleira = 1, Container = 1, Posicao = 2, Validade = DateTime.UtcNow.AddDays(1) }  // Válido
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockItems);

            // Act
            var expiredItems = await _itemService.GetExpiredItems();

            // Assert
            Assert.Single(expiredItems); // Deve haver apenas um item expirado
            Assert.Equal("Item Expirado", expiredItems.First().Nome); // O item expirado deve ser o "Item Expirado"
        }

        [Fact]
        public async Task Item_Validity_ShouldReturnTrue_WhenValid()
        {
        // Arrange
        var mockItems = new List<Item>
        {
            new Item { Nome = "Alface", Categoria = "Hortifruti", Prateleira = 1, Container = 1, Posicao = 1, Validade = DateTime.UtcNow.AddDays(1) }, // Válido
            new Item { Nome = "Cenoura", Categoria = "Hortifruti", Prateleira = 1, Container = 1, Posicao = 2, Validade = DateTime.UtcNow.AddDays(-1) }  // Expirado
        };

        _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(mockItems);

        // Act
        var items = await _itemService.GetAllItemsAsync();
        var validItem = items.FirstOrDefault(i => i.Nome == "Alface");

        // Assert
        Assert.NotNull(validItem); // Garante que o item "Alface" foi encontrado
        Assert.True(validItem.Validade > DateTime.UtcNow); // Validade posterior à data atual, 'Valido' deve ser true
        }

    }
}
