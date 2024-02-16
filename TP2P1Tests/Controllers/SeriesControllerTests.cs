using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP2P1.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP2P1.Models.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TP2P1.Controllers.Tests
{



    [TestClass()]
    public class SeriesControllerTests
    {
        private SeriesController controller;

        public SeriesControllerTests()
        {
            var builder = new DbContextOptionsBuilder<SeriesDBContext>().UseNpgsql("Server = localhost; port=5432;Database=SeriesDB; uid=postgres;password=postgres;");
            SeriesDBContext context = new SeriesDBContext(builder.Options);
            controller = new SeriesController(context);



        }

        [TestMethod()]
        public void GetSeries_SuccessfulTest()
        {
            var expectedSeries = new List<Serie>
            {
                new Serie { Serieid = 1, Titre = "Series 1", Resume = "Description 1" },
                new Serie { Serieid = 2, Titre = "Series 2", Resume = "Description 2" },
                new Serie { Serieid = 3, Titre = "Series 3", Resume = "Description 3" }
            };
            foreach (var serie in expectedSeries)
            {
                controller.PostSerie(serie);
            }


            var result = controller.GetSeries();



        }

        [TestMethod()]
        public void PutSerieTest()
        {
            var expectedSeries = new List<Serie>
            {
                new Serie { Serieid = 1, Titre = "Series 1", Resume = "Description 1" },
                new Serie { Serieid = 2, Titre = "Series 2", Resume = "Description 2" },
                new Serie { Serieid = 3, Titre = "Series 3", Resume = "Description 3" }
            };
            foreach (var serie in expectedSeries)
            {
                controller.PutSerie(serie.Serieid, serie);
            }
        }

        [TestMethod()]
        public void DeleteSerie_FailingTest()

        {
            var serieToDelete = new Serie { Serieid = 1, Titre = "Series 1", Resume = "Description 1" };
            controller.PostSerie(serieToDelete);
            controller.DeleteSerie(2);  

        }
    }
}