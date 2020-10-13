using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkeTryWriteTests
	{

		[Fact]
		public void TryWriteWithoutPathException()
		{
			Assert.False(BaseFileWorker.TryWrite("text", ""));
			Assert.False(BaseFileWorker.TryWrite("text", "", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "", 10));
		}

		[Fact]
		public void TryWriteWithoutFileNameException()
		{
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest"));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest", 10));
		}

		[Fact]
		public void TryWriteEmptyText()
		{
			Assert.True(BaseFileWorker.TryWrite("", "C:\\FileWokerTest\\TryWriteTest\\test.txt"));
			Assert.False(BaseFileWorker.TryWrite("", "C:\\FileWokerTest\\TryWriteTest\\test.txt", -1));
			Assert.False(BaseFileWorker.TryWrite("", "C:\\FileWokerTest\\TryWriteTest\\test.txt", 0));
			Assert.True(BaseFileWorker.TryWrite("", "C:\\FileWokerTest\\TryWriteTest\\test.txt", 10));
		}

		[Fact]
		public void TryWriteToNotExistingFile()
		{
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt"));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt", 0));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt", 10));
		}

		[Fact]
		public void TryWriteToExistingFile()
		{
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt"));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt", -1));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test.txt", 10));
		}

		[Fact]
		public void TryWriteToFileWithMissingLinkInPath()
		{
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test\\test.txt"));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test\\test.txt", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test\\test.txt", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\test\\test.txt", 10));
		}

		[Fact]
		public void TryWriteMultilineText()
		{
			Assert.True(BaseFileWorker.TryWrite(
				"To be, or not to be, that is the question:\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles\r\nAnd by opposing end them.",
				"C:\\FileWokerTest\\TryWriteTest\\William Shakespeare.txt"));
			Assert.False(BaseFileWorker.TryWrite(
				"To be, or not to be, that is the question:\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles\r\nAnd by opposing end them.",
				"C:\\FileWokerTest\\TryWriteTest\\William Shakespeare.txt", -1));
			Assert.False(BaseFileWorker.TryWrite(
				"To be, or not to be, that is the question:\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles\r\nAnd by opposing end them.",
				"C:\\FileWokerTest\\TryWriteTest\\William Shakespeare.txt", 0));
			Assert.True(BaseFileWorker.TryWrite(
				"To be, or not to be, that is the question:\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles\r\nAnd by opposing end them.",
				"C:\\FileWokerTest\\TryWriteTest\\William Shakespeare.txt", 10));
		}

		[Fact]
		public void TryWriteNotLatinTextFile()
		{
			Assert.True(BaseFileWorker.TryWrite(
				"У лукоморья дуб зеленый;\r\nЗлатая цепь на дубе том:\r\nИ днем и ночью кот ученый\r\nВсё ходит по цепи кругом;\r\nИдет направо — песнь заводит,\r\nНалево — сказку говорит.",
				"C:\\FileWokerTest\\TryWriteTest\\Пушкин.txt"));

			Assert.True(BaseFileWorker.TryWrite(
				"作品名：小林秀雄小論\r\n作品名読み：こばやしひでおしょうろん\r\n著者名：中原 中也",
				"C:\\FileWokerTest\\TryWriteTest\\中原 中也.txt"));

			Assert.True(BaseFileWorker.TryWrite("☺☻♥♫►", "C:\\FileWokerTest\\TryWriteTest\\☺☻♥♫►.txt"));

			Assert.False(BaseFileWorker.TryWrite(
				"У лукоморья дуб зеленый;\r\nЗлатая цепь на дубе том:\r\nИ днем и ночью кот ученый\r\nВсё ходит по цепи кругом;\r\nИдет направо — песнь заводит,\r\nНалево — сказку говорит.",
				"C:\\FileWokerTest\\TryWriteTest\\Пушкин.txt", -1));

			Assert.False(BaseFileWorker.TryWrite(
				"作品名：小林秀雄小論\r\n作品名読み：こばやしひでおしょうろん\r\n著者名：中原 中也",
				"C:\\FileWokerTest\\TryWriteTest\\中原 中也.txt", -1));

			Assert.False(BaseFileWorker.TryWrite("☺☻♥♫►", "C:\\FileWokerTest\\TryWriteTest\\☺☻♥♫►.txt", -1));

			Assert.False(BaseFileWorker.TryWrite(
				"У лукоморья дуб зеленый;\r\nЗлатая цепь на дубе том:\r\nИ днем и ночью кот ученый\r\nВсё ходит по цепи кругом;\r\nИдет направо — песнь заводит,\r\nНалево — сказку говорит.",
				"C:\\FileWokerTest\\TryWriteTest\\Пушкин.txt", 0));

			Assert.False(BaseFileWorker.TryWrite(
				"作品名：小林秀雄小論\r\n作品名読み：こばやしひでおしょうろん\r\n著者名：中原 中也",
				"C:\\FileWokerTest\\TryWriteTest\\中原 中也.txt", 0));

			Assert.False(BaseFileWorker.TryWrite("☺☻♥♫►", "C:\\FileWokerTest\\TryWriteTest\\☺☻♥♫►.txt", 0));

			Assert.True(BaseFileWorker.TryWrite(
				"У лукоморья дуб зеленый;\r\nЗлатая цепь на дубе том:\r\nИ днем и ночью кот ученый\r\nВсё ходит по цепи кругом;\r\nИдет направо — песнь заводит,\r\nНалево — сказку говорит.",
				"C:\\FileWokerTest\\TryWriteTest\\Пушкин.txt", 10));

			Assert.True(BaseFileWorker.TryWrite(
				"作品名：小林秀雄小論\r\n作品名読み：こばやしひでおしょうろん\r\n著者名：中原 中也",
				"C:\\FileWokerTest\\TryWriteTest\\中原 中也.txt", 10));

			Assert.True(BaseFileWorker.TryWrite("☺☻♥♫►", "C:\\FileWokerTest\\TryWriteTest\\☺☻♥♫►.txt", 10));
		}


		[Fact]
		public void TryWriteToSpecificFile()
		{
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0.5.2.docx"));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0524.torrent"));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\bell.png"));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG.Core.FileWorkingUtils.pdb"));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG"));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\sds.pdf"));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\vlc - 3.0.10 - win64.exe"));

			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0.5.2.docx", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0524.torrent", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\bell.png", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG.Core.FileWorkingUtils.pdb", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\sds.pdf", -1));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\vlc - 3.0.10 - win64.exe", -1));

			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0.5.2.docx", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0524.torrent", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\bell.png", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG.Core.FileWorkingUtils.pdb", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\sds.pdf", 0));
			Assert.False(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\vlc - 3.0.10 - win64.exe", 0));

			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0.5.2.docx", 10));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\0524.torrent", 10));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\bell.png", 10));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG.Core.FileWorkingUtils.pdb", 10));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\IIG", 10));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\sds.pdf", 10));
			Assert.True(BaseFileWorker.TryWrite("text", "C:\\FileWokerTest\\TryWriteTest\\vlc - 3.0.10 - win64.exe", 10));
		}
	}
}