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
            var entities = new List<T>
            {
                CreateEntityWithId()
            };

            resource
                .Setup(r => r.ReadAll())
                .Returns(entities);

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
            var entity = CreateEntity();
            var createdEntity = repository.Add(entity);
            Assert.NotEqual(default(int), createdEntity.Id);
        }

        [Fact]
        public void GetAllTest()
        {
            var entities = repository.GetAll();
            Assert.Single(entities, CreateEntityWithId());
        }
    }
}