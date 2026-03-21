using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Project.Controllers;
using Project.Data;
using Project.Models;
using NUnit;

namespace Project.Tests.Controllers
{
    public class SmerControllerTests
    {
       
        [Test]
        public async Task Index_ReturnsView_WithAllSmerovi()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("SmerDb_Test")
                .Options;

            using var context = new ApplicationDbContext(options);

            context.Smer.AddRange(
                new Smer { SmerId = 1, Ime = "IT" },
                new Smer { SmerId = 2, Ime = "Matematika" }
            );
            await context.SaveChangesAsync();

            var controller = new SmerController(context);

            var result = await controller.Index();

            var view = result as ViewResult;
            Assert.That(view, Is.Not.Null);
            var smerovi = view.Model as List<Smer>;
            Assert.That(smerovi, Is.Not.Null );
            Assert.That(smerovi[0].Ime, Is.EqualTo("IT"));
            Assert.That(smerovi[0].SmerId, Is.EqualTo(1));
            Assert.That(smerovi[1].Ime, Is.EqualTo("Matematika"));
            Assert.That(smerovi[1].SmerId, Is.EqualTo(2));

        }

        }
}

