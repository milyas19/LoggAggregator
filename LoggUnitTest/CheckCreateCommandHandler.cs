using Application.Create;
using Application.GetList;
using Application.GetSingleLog;
using AutoMapper;
using MediatR;
using Moq;
using NUnit.Framework;
using Persistence.Data.DBWrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LoggAggregatorModel = Entities.LoggAggregator;

namespace LoggUnitTest
{
    [TestFixture]
    public class CheckCreateCommandHandler
    {
        List<LoggAggregatorModel> dbEntries;
        Mock<IDBWrapper<LoggAggregatorModel>> wrapperMock;
        Mock<IMapper> imapperMock;

        [SetUp]
        public void Setup()
        {
            dbEntries = new List<LoggAggregatorModel>()
            {
                new LoggAggregatorModel()
                {
                    Id = 1,
                    CreatedDate = new DateTime(20, 01, 01).Date,
                    HostName = "TestHostName",
                    Message = "TestMessage",
                    Severity = "Info"
                },
                new LoggAggregatorModel()
                {
                    Id = 2,
                    CreatedDate = new DateTime(20, 01, 02).Date,
                    HostName = "TestHostName",
                    Message = "TestMessage",
                    Severity = "Error"
                },
                new LoggAggregatorModel()
                {
                    Id = 3,
                    CreatedDate = new DateTime(20, 01, 03).Date,
                    HostName = "TestHostName",
                    Message = "TestMessage",
                    Severity = "Error"
                }
            };
            wrapperMock = new Mock<IDBWrapper<LoggAggregatorModel>>();
            wrapperMock.Setup(x => x.Add(It.IsAny<LoggAggregatorModel>())).Returns(Task<LoggAggregatorModel>.FromResult(dbEntries.First()));
            wrapperMock.Setup(x => x.GetList()).Returns(Task<List<LoggAggregatorModel>>.FromResult(dbEntries));
            wrapperMock.Setup(x => x.GetSingle(It.IsAny<int>())).Returns(Task<LoggAggregatorModel>.FromResult(dbEntries.First()));

            imapperMock = new Mock<IMapper>();
            imapperMock.Setup(x => x.Map<List<LoggAggregatorModel>>(It.IsAny<List<LogDto>>()))
                .Returns((List<LogDto> source) =>
                {
                    var list = new List<LoggAggregatorModel>();
                    foreach (var item in source)
                    {
                        list.Add(new LoggAggregatorModel()
                        {
                            Id = item.Id,
                            HostName = item.HostName,
                            CreatedDate = item.CreatedDate,
                            Message = item.Message,
                            Severity = item.Severity
                        });
                    }
                    return list;
                });
            imapperMock.Setup(x => x.Map<List<LogDto>>(It.IsAny<List<LoggAggregatorModel>>()))
                .Returns((List<LoggAggregatorModel> source) =>
                {
                    var list = new List<LogDto>();
                    foreach (var item in source)
                    {
                        list.Add(new LogDto()
                        {
                            Id = item.Id,
                            HostName = item.HostName,
                            CreatedDate = item.CreatedDate,
                            Message = item.Message,
                            Severity = item.Severity
                        });
                    }
                    return list;
                });
        }

        [Test]
        public async Task CreateLogCommand_LogDataCreatedOnDatabase()
        {
            // Setup Test Request Parameters
            var createLogDto = new CreateLogDto
            {
                HostName = "TestHostName",
                Message = "TestMessage",
                Severity = "Error"
            };
            var createLogCommand = new CreateLogCommand(createLogDto);
            // Expected Result
            var expectedResult = new CreatedLogDto()
            {
                Id = 1,
                CreatedDate = new DateTime(20, 01, 01).Date,
                HostName = "TestHostName",
                Message = "TestMessage",
                Severity = "Error"
            };

            var handler = new CreateLogCommandHandler(wrapperMock.Object);
            var result = await handler.Handle(createLogCommand, new System.Threading.CancellationToken());

            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }

        [Test]
        public async Task GetLogList_LogListRetrieveFromDatabase()
        {
            var getListQuery = new GetListQuery(null);
            var handler = new GetListQueryHandler(wrapperMock.Object, imapperMock.Object);
            var result = await handler.Handle(getListQuery, new CancellationToken());

            Assert.AreEqual(dbEntries.Count, result.Count);
        }
        [Test]
        public async Task GetLogById_LogObjectRetrieveFromDatabase()
        {
            // Expected Result
            var expectedResult = new SingleLogDto()
            {
                Id = 1,
                CreatedDate = new DateTime(20, 01, 01).Date,
                HostName = "TestHostName",
                Message = "TestMessage",
                Severity = "Error"
            };
            var getSingleLogQuery = new GetLogQuery(1);
            var handler = new GetSingleLogQueryHandler(wrapperMock.Object);
            var result = await handler.Handle(getSingleLogQuery, new System.Threading.CancellationToken());

            Assert.AreEqual(expectedResult.ToString(), result.ToString());
        }
    }
}
