using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;
using ScoreFileSorter;

namespace FileSorterTest
{
    [TestFixture]
    public class ScoreSorterTest
    {
        private const string  _inputString  = "BUNDY, TERESSA, 88\r\nSMITH, ALLAN, 70\r\nKING, MADISON, 88\r\nSMITH, FRANCIS, 85";
        private const string  _outputString = "BUNDY, TERESSA, 88\r\nKING, MADISON, 88\r\nSMITH, FRANCIS, 85\r\nSMITH, ALLAN, 70\r\n";
        private const string _inputStringWithWhiteline = "BUNDY, TERESSA, 88\r\nSMITH, ALLAN, 70\r\n\r\n\r\nSmith,John\r\nTest\r\nKING, MADISON, 88\r\nSMITH, FRANCIS, 85";
        private const string _inputStringWithIncompleteRecords = "BUNDY, TERESSA, 88\r\nKING, MADISON, 88\r\nSMITH, FRANCIS, 85\r\nSMITH, ALLAN, 70\r\n";
        
        [SetUp]
        public void Setup()
        {

        }
       
        [TestCase(_inputString, _outputString,Description="ScoreSorter test - normal input")]
        [TestCase(_inputStringWithWhiteline, _outputString, Description = "ScoreSorter test - input with white lines")]
        [TestCase(_inputStringWithIncompleteRecords, _outputString, Description = "ScoreSorter test - input with white incomplete records")]
        public void TestScoreSorter(string inputString, string outputString)
        {
            TextReader reader = new StringReader(inputString);
            ScoreSorter sorter = new ScoreSorter();
            sorter.ReadInput(reader);
            var sb = new StringBuilder();
            TextWriter writer = new StringWriter(sb);
            
            sorter.WriteOutputFile(writer);
            Assert.AreEqual(outputString, sb.ToString());
        }

        [TestCase("sample.txt","sample-graded.txt")]
        [TestCase(@"c:\path\sample.txt", @"c:\path\sample-graded.txt")]
        [TestCase(@"c:\path\sample",@"c:\path\sample-graded.txt")]
        public void TestGetOutputFilename(string inputfilename,string outputfilename)
        {
            ScoreSorter sorter = new ScoreSorter();
            var filename = sorter.GetOutputfilename(inputfilename);
            Assert.AreEqual(outputfilename, filename);
        }
    }
}
