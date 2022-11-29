﻿using Barebone.Tests;
using FluentAssertions;
using Manufactures.Application.GarmentScrapTransactions.Queries.GetMutationScrap.TCKecil;
using Manufactures.Domain.GarmentScrapSources;
using Manufactures.Domain.GarmentScrapSources.ReadModels;
using Manufactures.Domain.GarmentScrapSources.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Manufactures.Tests.Queries.GarmentScrabTransactions
{
    public class XlsTCKecil_OutCommandHandler : BaseCommandUnitTest
    {
        private readonly Mock<IGarmentScrapTransactionRepository> _mockGarmentScrapTransactionRepository;
        private readonly Mock<IGarmentScrapTransactionItemRepository> _mockGarmentScrapTransactionItemRepository;

        public XlsTCKecil_OutCommandHandler()
        {
            _mockGarmentScrapTransactionRepository = CreateMock<IGarmentScrapTransactionRepository>();
            _mockGarmentScrapTransactionItemRepository = CreateMock<IGarmentScrapTransactionItemRepository>();
            _MockStorage.SetupStorage(_mockGarmentScrapTransactionRepository);
            _MockStorage.SetupStorage(_mockGarmentScrapTransactionItemRepository);
        }

        private GetXlsTCKecil_Out_QueryHandler CreateGetXlsTCKecil_Out_QueryHandler()
        {
            return new GetXlsTCKecil_Out_QueryHandler(_MockStorage.Object);
        }

        [Fact]
        public async Task Handle_StateUnderTest_ExpectedBehavior()
        {
            // Arrage
            GetXlsTCKecil_Out_QueryHandler unitUnderTest = CreateGetXlsTCKecil_Out_QueryHandler();
            CancellationToken cancellationToken = CancellationToken.None;

            Guid guidScrapTransaction = Guid.NewGuid();
            Guid guidScrapTransactionItem = Guid.NewGuid();
            Guid guidScrapClassification = Guid.NewGuid();
            Guid guidScrapSource = Guid.NewGuid();
            Guid guidScrapDest = Guid.NewGuid();

            _mockGarmentScrapTransactionItemRepository
                .Setup(s => s.Query)
                .Returns(new List<GarmentScrapTransactionItemReadModel>
                {
                    new GarmentScrapTransactionItem(guidScrapTransactionItem, guidScrapTransaction, guidScrapClassification, "class01", 20, 1, "", "").GetReadModel()
                }.AsQueryable());

            _mockGarmentScrapTransactionRepository
                .Setup(s => s.Query)
                .Returns(new List<GarmentScrapTransactionReadModel>
                {
                    new GarmentScrapTransaction(guidScrapTransaction, "", "IN", DateTimeOffset.Now, guidScrapSource, "", guidScrapDest, "" ).GetReadModel()
                }.AsQueryable());

            GetXlsTCKecil_Out_Query xlstckecil_out = new GetXlsTCKecil_Out_Query(DateTime.UtcNow, DateTime.UtcNow.AddDays(2), "token");

            // Act
            var result = await unitUnderTest.Handle(xlstckecil_out, cancellationToken);

            // Assert
            result.Should().NotBeNull();
        }
    }
}
