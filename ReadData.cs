using System.Collections.Generic;
using System.IO;

namespace NetCore
{
	static public class ReadData
	{

		public static List<FlashCard> Read(string FilePath)
		{
			List<FlashCard> ret = new List<FlashCard>();

			ret = GetFileData((FilePath));

			return ret;
		}

		static List<FlashCard> GetFileData(string FilePath)
		{
			List<FlashCard> ret = new List<FlashCard>();

			List<string> DataToParse = FindFilesOfType(FilePath,"*.fc");

			foreach (string File in DataToParse)
			{
				ret.AddRange(ParseFlashCardData(File));
			}

			return ret;
		}

		static List<string> FindFilesOfType(string theFilePath, string theFileType)
		{
			List<string> ret = new List<string>();

			string FilePath = theFilePath;

			string FileType = theFileType;

			DirectoryInfo ChosenDirectory = new DirectoryInfo(FilePath);

			foreach (var file in ChosenDirectory.GetFiles(FileType))
			{
				ret.Add(System.IO.File.ReadAllText(file.FullName));
			}

			return ret;
		}

		private static List<FlashCard> ParseFlashCardData(string StringToParse)
		{
			List<FlashCard> ret = new List<FlashCard>();

			bool CurrentIndexValid = true;

			while (CurrentIndexValid)
			{
				for (int i = 1; ;  i++)
				{
					string TempItem = string.Empty;
					string TempDef = string.Empty;

					int startindex = CustomIndexOf(StringToParse, '{', i);
					int endIndex = CustomIndexOf(StringToParse, '}', i);

					if (startindex == -1)
					{
						CurrentIndexValid = false;
						break;
					}

					TempItem = StringToParse.Substring(startindex + 1,endIndex - startindex - 1);

					startindex = CustomIndexOf(StringToParse, '(', i);
					endIndex = CustomIndexOf(StringToParse, ')', i);

					TempDef = StringToParse.Substring(startindex + 1,endIndex - startindex - 1);

					if (!string.IsNullOrEmpty(TempItem) && !string.IsNullOrEmpty(TempDef))
					{
						ret.Add(new FlashCard(){Item = TempItem,Definition = TempDef});
					}
				}
			}

			return ret;
		}

		private  static int CustomIndexOf(string source, char toFind, int position)
		{
			int index = -1;

			for (int i = 0; i < position; i++)

			{

				index = source.IndexOf(toFind, index + 1);

				if (index == -1)

					break;
			}

			return index;
		}
	}
}
