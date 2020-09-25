using System.Reflection;
using Enjin.SDK.Models;
using NUnit.Framework;
using static TestSuite.Utils.ReflectionUtils;

namespace TestSuite
{
    [TestFixture]
    public class ProjectTest
    {
        [Test]
        public void Id_GetsValue()
        {
            // Arrange
            const int expected = FakeProject.DefaultId;
            var project = CreateDefaultFakeProject();

            // Act
            var actual = project.Id;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Name_GetsValue()
        {
            // Arrange
            const string expected = FakeProject.DefaultName;
            var project = CreateDefaultFakeProject();

            // Act
            var actual = project.Name;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Description_GetsValue()
        {
            // Arrange
            const string expected = FakeProject.DefaultDescription;
            var project = CreateDefaultFakeProject();

            // Act
            var actual = project.Description;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Image_GetsValue()
        {
            // Arrange
            const string expected = FakeProject.DefaultImage;
            var project = CreateDefaultFakeProject();

            // Act
            var actual = project.Image;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void CreatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakeProject.DefaultCreatedAt;
            var project = CreateDefaultFakeProject();

            // Act
            var actual = project.CreatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void UpdatedAt_GetsValue()
        {
            // Arrange
            const string expected = FakeProject.DefaultUpdatedAt;
            var project = CreateDefaultFakeProject();

            // Act
            var actual = project.UpdatedAt;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static Project CreateDefaultFakeProject() => new FakeProject();
        
        private class FakeProject : Project
        {
            public const int DefaultId = 1;
            public const string DefaultName = "DefaultName";
            public const string DefaultDescription = "DefaultDescription";
            public const string DefaultImage = "DefaultImage";
            public const string DefaultCreatedAt = "DefaultCreatedAt";
            public const string DefaultUpdatedAt = "DefaultUpdatedAt";
            
            private static readonly PropertyInfo ID_PROPERTY;
            private static readonly PropertyInfo NAME_PROPERTY;
            private static readonly PropertyInfo DESCRIPTION_PROPERTY;
            private static readonly PropertyInfo IMAGE_PROPERTY;
            private static readonly PropertyInfo CREATED_AT_PROPERTY;
            private static readonly PropertyInfo UPDATED_AT_PROPERTY;

            static FakeProject()
            {
                var type = typeof(Project);
                ID_PROPERTY = GetPublicProperty(type, "Id");
                NAME_PROPERTY = GetPublicProperty(type, "Name");
                DESCRIPTION_PROPERTY = GetPublicProperty(type, "Description");
                IMAGE_PROPERTY = GetPublicProperty(type, "Image");
                CREATED_AT_PROPERTY = GetPublicProperty(type, "CreatedAt");
                UPDATED_AT_PROPERTY = GetPublicProperty(type, "UpdatedAt");
            }

            public FakeProject(int id = DefaultId,
                               string name = DefaultName,
                               string description = DefaultDescription,
                               string image = DefaultImage,
                               string createdAt = DefaultCreatedAt,
                               string updatedAt = DefaultUpdatedAt)
            {
                ID_PROPERTY.SetValue(this, id);
                NAME_PROPERTY.SetValue(this, name);
                DESCRIPTION_PROPERTY.SetValue(this, description);
                IMAGE_PROPERTY.SetValue(this, image);
                CREATED_AT_PROPERTY.SetValue(this, createdAt);
                UPDATED_AT_PROPERTY.SetValue(this, updatedAt);
            }
        }
    }
}