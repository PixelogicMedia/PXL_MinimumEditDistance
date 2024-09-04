using System;
using System.Net;
using FluentAssertions;
using NUnit.Framework;

namespace MinimumEditDistance.Tests
{
    [TestFixture]
    public class BigStrings
    {
       
        [Test]
        //[ExpectedException(typeof(OutOfMemoryException))]
        public void Test_allocation_of_rectangular_array_over_2gb_in_size_throws()
        {
            var d = new RectangularArray(23171, 23170);
        }

        [Test]
        public void Test_allocation_of_rectangular_array_under_2gb_in_size_doesnt_throw() {
            var d = new RectangularArray(23170, 23170);
        }

        [Test]
        public void Test_grid_over_2GB()
        {
#pragma warning disable SYSLIB0014 // Type or member is obsolete
            var webClient = new WebClient();
#pragma warning restore SYSLIB0014 // Type or member is obsolete
            var html1 = webClient.DownloadString("http://www.google.com");
            var s = html1.Substring(0, 23743); // 4*23743^2 = 2.1gb memory
            
            var distance = Levenshtein.CalculateDistance(s, s, 1);
            distance.Should().Be(0);
        }
    }
}