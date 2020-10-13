using Xunit;
using IIG.FileWorker;

namespace TestingLab2
{
	public class FileWorkerReadLinesTests
	{

		[Fact]
		public void ReadLinesWithoutPathException()
		{
			Assert.Null(BaseFileWorker.ReadLines(""));
		}

		[Fact]
		public void ReadLinesWithWrongPath()
		{
			Assert.Null(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\wrong"));
			Assert.Null(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest1\\William Shakespeare.txt"));
		}

		[Fact]
		public void ReadLinesFromFile()
		{
			Assert.Equal(
				new string[] {
					"To be, or not to be, that is the question:",
					"Whether 'tis nobler in the mind to suffer",
					"The slings and arrows of outrageous fortune,",
					"Or to take arms against a sea of troubles",
					"And by opposing end them."
				},				
				BaseFileWorker.ReadLines("C:\\FileWokerTest\\ReadTest\\William Shakespeare.txt"
				));
		}

		[Fact]
		public void ReadLinesFromFileNotLatinNameAndInsert()
		{
			Assert.Equal(
				new string[] {
					"У лукоморья дуб зеленый;",
					"Златая цепь на дубе том:",
					"И днем и ночью кот ученый",
					"Всё ходит по цепи кругом;",
					"Идет направо — песнь заводит,",
					"Налево — сказку говорит."
				},
				BaseFileWorker.ReadLines("C:\\FileWokerTest\\ReadTest\\Пушкин.txt"
				));
			Assert.Equal(
				new string[] {
					"作品名：小林秀雄小論",
					"作品名読み：こばやしひでおしょうろん",
					"著者名：中原 中也",
				},
				BaseFileWorker.ReadLines("C:\\FileWokerTest\\ReadTest\\中原 中也.txt"
				));
		}

		[Fact]
		public void ReadLinesFromSpecificFiles()
		{
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\.travis.yml"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\pom.xml"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\system.properties"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\QuizApplication.java"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\IIG"));
			Assert.NotNull(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\IIG.Core.FileWorkingUtils.pdb"));
		}

		[Fact]
		public void ReadLinesFromNotTextFiles()
		{
			Assert.Null(BaseFileWorker.ReadAll("C:\\FileWokerTest\\ReadTest\\vlc - 3.0.10 - win64.exe"));
			}

	}
}
