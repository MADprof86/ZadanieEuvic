using NUnit.Framework;
using System;
using ZadanieEuvic;
using Moq;

namespace ZadanieEuvicTests
{
    public class FileReaderTests
    {
        FileReader fileReader;
        [SetUp]
        public void Setup()
        {
            fileReader = new FileReader();
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public void ReadGivenFile_EmptyStringOrWhiteSpace_ThrowsArgumentNullException(string error)
        {
            Assert.That(()=> fileReader.ReadGivenFile(error), Throws.ArgumentNullException);
        }
        [Test]
        [TestCase("a.txt")]
        public void ReadGivenFile_StringGivesInvalidFileName_ThrowsArgumentNullException(string error)
        {
            var fileReaderMock = new Mock<IReadGivenFile>();
            fileReaderMock.Setup(fr => fr.ReadGivenFile(error)).Throws(new ArgumentNullException());
            Assert.That(() => fileReaderMock.Object.ReadGivenFile("a.txt"), Throws.ArgumentNullException);
        }
        [Test]
        [TestCase("FileNotEmpty","a")]
        [TestCase("FileEmpty","")]
        public void ReadGivenFile_ThePathOIsCorrect_ReturnsString(string casE, string output)
        {
            var fileReaderMock = new Mock<IReadGivenFile>();
            fileReaderMock.Setup(fr => fr.ReadGivenFile(casE)).Returns(output);
            Assert.That(() => fileReaderMock.Object.ReadGivenFile(casE), Is.EqualTo(output));
        }
    }
}