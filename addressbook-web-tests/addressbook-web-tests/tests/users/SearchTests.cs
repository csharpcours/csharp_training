﻿using NUnit.Framework;
using System.Collections.Generic;



namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {

        [Test]
        public void TestSearch()
        {
            System.Console.Out.Write(app.Users.GetNumberOffresults());
        }
    }
}
