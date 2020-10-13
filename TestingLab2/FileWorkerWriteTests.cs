using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkeWriteTests
	{

		[Fact]
		public void WriteWithoutPathException()
		{
			Assert.False(BaseFileWorker.Write("text", ""));
		}

		[Fact]
		public void WriteWithoutFileNameException()
		{
			Assert.False(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest"));
		}

		[Fact]
		public void WriteEmptyText()
		{
			Assert.True(BaseFileWorker.Write("", "C:\\FileWokerTest\\WriteTest\\test.txt"));
		}

		[Fact]
		public void WriteToNotExistingFile()
		{
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\test.txt"));
		}

		[Fact]
		public void WriteToExistingFile()
		{
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\test.txt"));
		}

		[Fact]
		public void WriteToFileWithMissingLinkInPath()
		{
			Assert.False(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\test\\test.txt"));
		}

		[Fact]
		public void WriteMultilineText()
		{
			Assert.True(BaseFileWorker.Write(
				"To be, or not to be, that is the question:\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles\r\nAnd by opposing end them.",
				"C:\\FileWokerTest\\WriteTest\\William Shakespeare.txt"));
		}

		[Fact]
		public void WriteNotLatinTextFile()
		{
			Assert.True(BaseFileWorker.Write(
				"У лукоморья дуб зеленый;\r\nЗлатая цепь на дубе том:\r\nИ днем и ночью кот ученый\r\nВсё ходит по цепи кругом;\r\nИдет направо — песнь заводит,\r\nНалево — сказку говорит.",
				"C:\\FileWokerTest\\WriteTest\\Пушкин.txt"));

			Assert.True(BaseFileWorker.Write(
				"作品名：小林秀雄小論\r\n作品名読み：こばやしひでおしょうろん\r\n著者名：中原 中也",
				"C:\\FileWokerTest\\WriteTest\\中原 中也.txt"));

			Assert.True(BaseFileWorker.Write("☺☻♥♫►", "C:\\FileWokerTest\\WriteTest\\☺☻♥♫►.txt"));
		}


		[Fact]
		public void WriteToSpecificFile()
		{
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\0.5.2.docx"));
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\0524.torrent"));
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\bell.png"));
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\IIG.Core.FileWorkingUtils.pdb"));
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\IIG"));
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\sds.pdf"));
			Assert.True(BaseFileWorker.Write("text", "C:\\FileWokerTest\\WriteTest\\vlc - 3.0.10 - win64.exe"));
		}
	}
}