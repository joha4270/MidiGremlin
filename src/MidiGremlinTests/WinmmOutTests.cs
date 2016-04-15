﻿using NUnit.Framework;
using MidiGremlin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MidiGremlin.Tests
{
    [TestFixture()]
    public class WinmmOutTests
    {
        [Test()]
        public void WinmmOutTest ()
        {
            new WinmmOut(0);
            Thread.Sleep(1000);
            Assert.Pass();
        }

        [Test()]
        public void DisposeTest ()
        {
            Assert.Fail();
        }

        [Test()]
        public void CurrentTimeTest ()
        {
            Assert.Fail();
        }

        [Test()]
        public void QueueMusicTest ()
        {
            Assert.Fail();
        }
    }
}