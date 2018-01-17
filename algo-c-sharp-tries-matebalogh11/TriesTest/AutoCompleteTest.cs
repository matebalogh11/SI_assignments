using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TriesLogic;

namespace TriesTest
{
    [TestFixture]
    public class AutoCompleteTest
    {
        [Test]
        public void Add_oneWord_fullSearch()
        {
            AutoComplete ac = new AutoComplete();
            ac.AddWord("test");

            List<String> results = ac.GetCompletions("test");
            List<String> expected = new List<string>() { "test" };
            Assert.IsTrue(expected.SequenceEqual(results), "Expexted test word completion does not match with the acutal one.");
        }

        [Test]
        public void Add_oneWord_partialSearch()
        {
            AutoComplete ac = new AutoComplete();
            ac.AddWord("aReallyLongWord");

            List<String> results = ac.GetCompletions("aReally");
            List<String> expected = new List<string>() { "aReallyLongWord" };
            Assert.IsTrue(expected.SequenceEqual(results));
        }

        [Test]
        public void Add_oneWord_wrongSearch()
        {
            AutoComplete ac = new AutoComplete();
            ac.AddWord("aReallyLongWord");

            List<String> results = ac.GetCompletions("Word");
            Assert.AreEqual(0, results.Count());
        }

        [Test]
        public void Add_oneWord_caseInsensitive()
        {
            AutoComplete ac = new AutoComplete();
            ac.AddWord("aReallyLongWord");

            List<String> results = ac.GetCompletions("AREALLY");
            List<String> expected = new List<string>() { "aReallyLongWord" };
            Assert.IsTrue(expected.SequenceEqual(results));
        }

        [Test]
        public void Add_lotsOfWords()
        {
            string path = @"./assets/wordlist.txt";            
            AutoComplete autoComplete = new AutoComplete();

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    autoComplete.AddWord(streamReader.ReadLine());
                }
            }

            List<String> results = autoComplete.GetCompletions("spectro");
            List<String> expected = new List<string>(){"spectrogram", "spectrograph", "spectrographic",
                    "spectrographically", "spectrometric", "spectrophotometer", "spectroscope",
                    "spectroscopic", "spectroscopy" };
            Assert.IsTrue(expected.SequenceEqual(results));
        }

        [Test]
        public void Remove_existingWord()
        {
            AutoComplete ac = new AutoComplete();
            ac.AddWord("aReallyLongWord");

            Assert.IsTrue(ac.RemoveWord("aReallyLongWord"));
            Assert.AreEqual(0, ac.GetCompletions("aReallyLongWord").Count());
        }

        [Test]
        public void Remove_nonExistingWord()
        {
            AutoComplete ac = new AutoComplete();
            ac.AddWord("aReallyLongWord");

            Assert.IsTrue(ac.RemoveWord("LongWord"));
            Assert.AreEqual(1, ac.GetCompletions("aReallyLongWord").Count());
        }
    }
}
