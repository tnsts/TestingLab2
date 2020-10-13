using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkerGetPathUnitTests
	{

		[Fact]
		public void GetFilePathWithoutPath()
		{
			Assert.Null(BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest"));
		}

		[Fact]
		public void GetPathFOrNotExistingFile()
		{
			Assert.Null(BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\void"));
		}

		[Fact]
		public void GetPathWithoutExtencion()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG"));
		}

		[Fact]
		public void GetPathWithSpecificAlphabetName()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\신의 탑.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\鋼の錬金術師.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\นรางามิ เทวดาขาจร.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\Тест єії'.txt"));
		}

		[Fact]
		public void GetPathWithAltCodesName()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\☺☻♥♫►.txt"));
		}

		[Fact]
		public void GetPathForTextFile()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\0.5.2.docx"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\Neechy.pptx"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\test.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\sds.pdf"));
		}

		[Fact]
		public void GetMultimediaFilePath()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\ms18.mp4"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\DUSTCELL - DERO.mp3"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\bell.png"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\pexels-photo-4173624.jpeg"));
		}

		[Fact]
		public void GetSpecialFilePath()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\0524.torrent"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG.Core.FileWorkingUtils.pdb"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\vlc-3.0.10-win64.exe"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest", BaseFileWorker.GetPath("C:\\FileWokerTest\\GetFilesSomethingTest\\-73_1_1.zip"));

		}

	}
}
