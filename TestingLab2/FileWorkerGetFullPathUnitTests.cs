using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkerGetFullPathUnitTests
	{

		[Fact]
		public void GetFilePathWithoutFullPath()
		{
			Assert.Null(BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest"));
		}

		[Fact]
		public void GetFullPathFOrNotExistingFile()
		{
			Assert.Null(BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\void"));
		}

		[Fact]
		public void GetFullPathWithoutExtencion()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG"));
		}

		[Fact]
		public void GetFullPathWithSpecificAlphabetName()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\신의 탑.txt", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\신의 탑.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\鋼の錬金術師.txt", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\鋼の錬金術師.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\นรางามิ เทวดาขาจร.txt", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\นรางามิ เทวดาขาจร.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\Тест єії'.txt", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\Тест єії'.txt"));
		}

		[Fact]
		public void GetFullPathWithAltCodesName()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\☺☻♥♫►.txt", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\☺☻♥♫►.txt"));
		}

		[Fact]
		public void GetFullPathForTextFile()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\0.5.2.docx", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\0.5.2.docx"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\Neechy.pptx", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\Neechy.pptx"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\test.txt", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\test.txt"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\sds.pdf", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\sds.pdf"));
		}

		[Fact]
		public void GetMultimediaFileFullPath()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\ms18.mp4", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\ms18.mp4"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\DUSTCELL - DERO.mp3", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\DUSTCELL - DERO.mp3"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\bell.png", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\bell.png"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\pexels-photo-4173624.jpeg", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\pexels-photo-4173624.jpeg"));
		}

		[Fact]
		public void GetSpecialFileFullPath()
		{
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\0524.torrent", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\0524.torrent"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG.Core.FileWorkingUtils.pdb", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\IIG.Core.FileWorkingUtils.pdb"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\vlc-3.0.10-win64.exe", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\vlc-3.0.10-win64.exe"));
			Assert.Equal("C:\\FileWokerTest\\GetFilesSomethingTest\\-73_1_1.zip", BaseFileWorker.GetFullPath("C:\\FileWokerTest\\GetFilesSomethingTest\\-73_1_1.zip"));

		}

	}
}
