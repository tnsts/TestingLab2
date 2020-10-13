using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkerGetFileNameUnitTests
	{
		
		[Fact]
		public void GetFileNameWithoutPath()
		{
			Assert.Null(BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest"));
		}

		[Fact]
		public void GetNotExistingFileName()
		{
			Assert.Null(BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\void"));
		}

		[Fact]
		public void GetFileWithoutExtencionName()
		{
			Assert.Equal("IIG", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG"));
		}

		[Fact]
		public void GetFileWithSpecificAlphabetName()
		{
			Assert.Equal("신의 탑.txt", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\신의 탑.txt"));
			Assert.Equal("鋼の錬金術師.txt", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\鋼の錬金術師.txt"));
			Assert.Equal("นรางามิ เทวดาขาจร.txt", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\นรางามิ เทวดาขาจร.txt"));
			Assert.Equal("Тест єії'.txt", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\Тест єії'.txt"));
		}

		[Fact]
		public void GetFileWithAltCodesName()
		{
			Assert.Equal("☺☻♥♫►.txt", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\☺☻♥♫►.txt"));
		}

		[Fact]
		public void GetTextFileName()
		{
			Assert.Equal("0.5.2.docx", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\0.5.2.docx"));
			Assert.Equal("Neechy.pptx", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\Neechy.pptx"));
			Assert.Equal("test.txt", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\test.txt"));
			Assert.Equal("sds.pdf", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\sds.pdf"));
		}

		[Fact]
		public void GetMultimediaFileName()
		{
			Assert.Equal("ms18.mp4", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\ms18.mp4"));
			Assert.Equal("DUSTCELL - DERO.mp3", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\DUSTCELL - DERO.mp3"));
			Assert.Equal("bell.png", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\bell.png"));
			Assert.Equal("pexels-photo-4173624.jpeg", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\pexels-photo-4173624.jpeg"));
		}

		[Fact]
		public void GetSpecialFileName()
		{
			Assert.Equal("0524.torrent", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\0524.torrent"));
			Assert.Equal("IIG.Core.FileWorkingUtils.pdb", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG.Core.FileWorkingUtils.pdb"));
			Assert.Equal("vlc-3.0.10-win64.exe", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\vlc-3.0.10-win64.exe"));
			Assert.Equal("-73_1_1.zip", BaseFileWorker.GetFileName("C:\\FileWokerTest\\GetFilesSomethingTest\\-73_1_1.zip"));

		}
	}
}
