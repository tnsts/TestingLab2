using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkerMkDirTests
	{

		[Fact]
		public void MkDirWithoutPathException()
		{
			Assert.Throws<System.ArgumentException>(() => BaseFileWorker.MkDir(""));
		}

		[Fact]
		public void DuplicateMkDir()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.MkDir("C:\\FileWokerTest\\GetFilesSomethingTest"));
		}

		[Fact]
		public void ExecuteMkDirWithMIssingLink()
		{
			Assert.Equal("C:\\FileWokerTest\\NotExist\\MkDirTest", BaseFileWorker.MkDir("C:\\FileWokerTest\\NotExist\\MkDirTest"));
		}

		[Fact]
		public void ExecuteMkDirWithEmptyLink()
		{
			Assert.Equal("C:\\FileWokerTest\\MkDirEmptyLinkTest", BaseFileWorker.MkDir("C:\\FileWokerTest\\"+"\\MkDirEmptyLinkTest"));
		}

		[Fact]
		public void ExecuteMkDirWithSpecialSymbols()
		{
			Assert.Equal("C:\\FileWokerTest\\MkDirTest.java", BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDirTest.java"));
			Assert.Throws<System.IO.IOException>(() => BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDir:Test"));
			Assert.Throws<System.IO.IOException>(() => BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDir*Test"));
			Assert.Throws<System.IO.IOException>(() => BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDir?Test"));
			Assert.Throws<System.IO.IOException>(() => BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDir<>Test"));
			Assert.Throws<System.IO.IOException>(() => BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDir|Test"));
			Assert.Throws<System.IO.IOException>(() => BaseFileWorker.MkDir("C:\\FileWokerTest\\MkDir\'\"Test"));
		}

		[Fact]
		public void ExecuteMkDirWithSpacesName()
		{
			Assert.Equal("C:\\FileWokerTest\\", BaseFileWorker.MkDir("C:\\FileWokerTest\\   "));
		}

		[Fact]
		public void ExecuteMkDirWithSpacesWraping()
		{
			Assert.Equal("C:\\FileWokerTest\\   test", BaseFileWorker.MkDir("C:\\FileWokerTest\\   test    "));
		}

		[Fact]
		public void ExecuteMkDirWithSpacesLink()
		{
			Assert.Equal("C:\\FileWokerTest\\   \\SpacesTest", BaseFileWorker.MkDir("C:\\FileWokerTest\\   \\SpacesTest"));
		}

		[Fact]
		public void MkDirWithSpecialName()
		{
			Assert.Equal("C:\\FileWokerTest\\신의 탑", BaseFileWorker.MkDir("C:\\FileWokerTest\\신의 탑"));
			Assert.Equal("C:\\FileWokerTest\\鋼の錬金術師", BaseFileWorker.MkDir("C:\\FileWokerTest\\鋼の錬金術師"));
			Assert.Equal("C:\\FileWokerTest\\นรางามิ เทวดาขาจร", BaseFileWorker.MkDir("C:\\FileWokerTest\\นรางามิ เทวดาขาจร"));
			Assert.Equal("C:\\FileWokerTest\\Тест єії", BaseFileWorker.MkDir("C:\\FileWokerTest\\Тест єії"));
			Assert.Equal("C:\\FileWokerTest\\☺☻♥♫►", BaseFileWorker.MkDir("C:\\FileWokerTest\\☺☻♥♫►"));
		}


		[Fact]
		public void MkDirWithForbiddenNames()
		{
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BaseFileWorker.MkDir("CON"));
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BaseFileWorker.MkDir("PRN"));
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BaseFileWorker.MkDir("COM1"));
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BaseFileWorker.MkDir("AUX"));
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BaseFileWorker.MkDir("NUL"));
			Assert.Throws<System.IO.DirectoryNotFoundException>(() => BaseFileWorker.MkDir("LPT1"));
		}
	}
}
