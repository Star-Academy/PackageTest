using System;
using System.Collections.Generic;
using Education.Models;
using Education.Repository;
using Xunit;
using Moq;
using System.Linq;

namespace Education.Test
{
    public abstract class RepositoryTests<T> where T : IModel
    {
        private readonly IRepository<T> repository;

        protected RepositoryTests()
        {
            var resource = CreateResourceMock();
            repository = new Repository<T>(resource);
        }

        private IResource<T> CreateResourceMock()
        {
            var resource = new Mock<IResource<T>>();

            resource.Setup(r => r.WriteAll(It.IsAny<IEnumerable<T>>()));
            resource.Setup(r => r.ReadAll()).Returns(new List<T> { CreateEntityWithId() });

            return resource.Object;
        }

        private T CreateEntityWithId()
        {
            var entity = CreateEntity();
            entity.Id = 1;
            return entity;
        }

        protected abstract T CreateEntity();

        [Fact]
        public void AddTest()
        {
            var createdEntity = AddEntity();
            Assert.NotEqual(default(int), createdEntity.Id);
        }

        private T AddEntity()
        {
            var entity = CreateEntity();
            return repository.Add(entity);
        }

        [Fact]
        public void GetAllTest()
        {
            var entities = repository.GetAll();

            Assert.NotEmpty(entities);
        }
    }
}