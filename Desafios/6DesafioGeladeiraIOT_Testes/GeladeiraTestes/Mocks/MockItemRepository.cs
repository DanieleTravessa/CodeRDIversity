using Moq;
using GeladeiraSOLID.Data;
using GeladeiraSOLID.Models;
using System;
using System.Collections.Generic;
using GeladeiraSOLID.Repositories;

namespace GeladeiraSOLID.Tests.Mocks
{
    public static class MockItemRepository
    {
        public static Mock<IItemRepository> GetMockItemRepository()
        {
            var mockRepo = new Mock<IItemRepository>();

            // Mockando a chamada GetById
            mockRepo.Setup(repo => repo.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) =>
                {
                    return new Item
                    {
                        Id = id,
                        Nome = "Tomate",
                        Categoria = "Hortifruti",
                        Validade = DateTime.Today.AddDays(-1),
                        Prateleira = 1,
                        Container = 1,
                        Posicao = 1
                    };
                });

            // Mockando a chamada GetAll
            mockRepo.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(new List<Item>
                {
                    new Item { Id = 1, Nome = "Tomate", Categoria = "Hortifruti", Validade = DateTime.Today.AddDays(-1), Prateleira = 1, Container = 1, Posicao = 1 },
                    new Item { Id = 2, Nome = "Alface", Categoria = "Hortifruti", Validade = DateTime.Today.AddDays(2), Prateleira = 1, Container = 2, Posicao = 2 }
                });

            return mockRepo;
        }
    }
}
