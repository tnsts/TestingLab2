using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkerReadAllTests
	{

		[Fact]
		public void ReadAllWithoutPathException()
		{
			Assert.Null(BaseFileWorker.ReadAll(""));
		}

		[Fact]
		public void ReadAllWithWrongPath()
		{
			Assert.Null(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\wrong"));
			Assert.Null(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest1\\William Shakespeare.txt"));
		}

		[Fact]
		public void ReadAllFromFile()
		{
			Assert.Equal(
				"To be, or not to be, that is the question:\r\nWhether 'tis nobler in the mind to suffer\r\nThe slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles\r\nAnd by opposing end them.",
				BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\William Shakespeare.txt"
				));
		}

		[Fact]
		public void ReadAllFromFileNotLatinNameAndInsert()
		{
			Assert.Equal(
				"У лукоморья дуб зеленый;\r\nЗлатая цепь на дубе том:\r\nИ днем и ночью кот ученый\r\nВсё ходит по цепи кругом;\r\nИдет направо — песнь заводит,\r\nНалево — сказку говорит.",
				BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\Пушкин.txt"
				));
			Assert.Equal(
				"作品名：小林秀雄小論\r\n作品名読み：こばやしひでおしょうろん\r\n著者名：中原 中也",
				BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\中原 中也.txt"
				));
		}

		[Fact]
		public void ReadAllFromSpecificFiles()
		{
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\.travis.yml"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\pom.xml"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\system.properties"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\QuizApplication.java"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\IIG"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\IIG.Core.FileWorkingUtils.pdb"));
		}

		[Fact]
		public void ReadAllFromNotTextFiles()
		{
			Assert.Null(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\vlc - 3.0.10 - win64.exe"));
			}

	}
}
