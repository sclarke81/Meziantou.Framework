﻿using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meziantou.Framework.Tests
{
    [TestClass]
    public class DebouceExtensionsTests
    {
        [TestMethod]
        [Ignore("Fails in CI")]
        public async Task DebounceTests()
        {
            var count = 0;
            var debounced = DebounceExtensions.Debounce(() => count++, TimeSpan.FromMilliseconds(30));

            debounced();
            debounced();
            await Task.Delay(70).ConfigureAwait(false);
            Assert.AreEqual(1, count);

            debounced();
            await Task.Delay(15).ConfigureAwait(false);
            debounced();
            await Task.Delay(15).ConfigureAwait(false);
            debounced();
            await Task.Delay(15).ConfigureAwait(false);
            debounced();

            await Task.Delay(50).ConfigureAwait(false);
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        [Ignore("Fails in CI")]
        public async Task Debounce_CallActionsWithArgumentsOfTheLastCall()
        {
            int lastArg = default;
            var debounced = DebounceExtensions.Debounce<int>(i => lastArg = i, TimeSpan.FromMilliseconds(0));

            debounced(1);
            debounced(2);
            await Task.Delay(1).ConfigureAwait(false);
            Assert.AreEqual(2, lastArg);
        }
    }
}
