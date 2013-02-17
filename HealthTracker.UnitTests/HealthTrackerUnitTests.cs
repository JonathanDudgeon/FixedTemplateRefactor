using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FixedTemplateRefactor.DomainX.DataBase;

namespace HealthTracker.UnitTests
{
    [TestClass]
    public class HealthTrackerUnitTests
    {
        private const string PersonOriginal = "John Doe";
        private const string PersonNew = "New Person";
        private const string PersonNameUpdated = "Updated Name";

        /// <summary>
        /// Delete any non-sample People from the database created by previous tests
        /// </summary>
        [TestInitialize]
        public void RemoveNonSamplePeople()
        {
            var thingy = new FixedTemplateRefactor.DomainX.DataBase.Meal();
            using (var db = new HealthTrackerEntities())
            {
                var peopleToDelete = db.People
                    .Where(person => person.PersonId > 4);

                foreach (var personToDelete in peopleToDelete)
                {
                    db.People.Remove(personToDelete);
                }
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Return the count of People in the database, which should be 4.
        /// </summary>
        [TestMethod]
        public void PersonCountTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                var personCount = (db.People.Select(p => p)).Count();
                Assert.IsTrue(personCount > 0);
            }
        }

        /// <summary>
        /// Return the PersonId of 'John Doe', which should be is 1.
        /// </summary>
        [TestMethod]
        public void PersonIdTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                var personId = db.People
                    .Where(person => person.Name == PersonOriginal)
                    .Select(person => person.PersonId)
                    .First();
                Assert.AreEqual(1, personId);
            }
        }
        /// <summary>
        /// Insert a new Person into the database.
        /// </summary>
        [TestMethod]
        public void PersonAddNewTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                // Setup test
                db.People.Add(new Person { Name = PersonNew });
                db.SaveChanges();

                // Test 1
                var personCount = (db.People.Select(p => p)).Count();
                Assert.AreEqual(5, personCount);

                // Test 2
                var newPersonFound = db.People.FirstOrDefault(
                    person => person.Name == PersonNew);
                Assert.IsNotNull(newPersonFound);
            }
        }

        /// <summary>
        /// Update a Person's name in the database.
        /// </summary>
        [TestMethod]
        public void PersonUpdateNameTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                // Setup test
                var personToUpdate = db.People.FirstOrDefault(
                    person => person.Name == PersonOriginal);

                if (personToUpdate != null) personToUpdate.Name = PersonNameUpdated;
                db.SaveChanges();

                // Test
                var updatedPerson = db.People.FirstOrDefault(
                    person => person.Name == PersonNameUpdated);
                Assert.IsNotNull(updatedPerson);

                // Tear down test
                var personToRevert = db.People.FirstOrDefault(
                    person => person.Name == PersonNameUpdated);

                if (personToRevert != null) personToRevert.Name = PersonOriginal;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Return the Meal count from PersonSummaryViews database view, which should be 21.
        /// </summary>
        [TestMethod]
        public void PersonSummaryViewTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                var mealCount = (db.PersonSummaryViews
                    .Where(p => p.PersonId == 1)
                    .Select(p => p.MealsCount))
                    .First();
                Assert.AreEqual(21, mealCount);
            }
        }

        /// <summary>
        /// Call CountActivities scalar-valued function directly from in the database.
        /// </summary>
        [TestMethod]
        public void ActivtyCountFunctionFromDatabaseTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                object[] parameters = { 1 };
                var activityCount = db.Database.SqlQuery<int>(
                    "SELECT [dbo].[CountActivities] ({0})",
                    parameters).FirstOrDefault();
                Assert.AreEqual(7, activityCount);
            }
        }

        /// <summary>
        /// Call CountActivities scalar-valued function from the Data Entity Model.
        /// </summary>
        [TestMethod]
        public void ActivtyCountFunctionFromEntityTest()
        {
            using (var db = new HealthTrackerEntities())
            {
                var activityCount = db.CountActivities(1).First();
                if (activityCount != null) activityCount = activityCount.Value;
                Assert.AreEqual(7, activityCount);
            }
        }
    }
}